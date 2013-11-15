namespace LinqToQuerystring
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Antlr.Runtime;
    using Antlr.Runtime.Tree;

    using LinqToQuerystring.TreeNodes;
    using LinqToQuerystring.TreeNodes.Base;

    public static class Extensions
    {
        public static TResult LinqToQuerystring<T, TResult>(this IQueryable<T> query, string queryString = "", bool forceDynamicProperties = false, int maxPageSize = -1)
        {
            return (TResult)LinqToQuerystring(query, typeof(T), queryString, forceDynamicProperties, maxPageSize);
        }

        public static IQueryable<T> LinqToQuerystring<T>(this IQueryable<T> query, string queryString = "", bool forceDynamicProperties = false, int maxPageSize = -1)
        {
            return (IQueryable<T>)LinqToQuerystring(query, typeof(T), queryString, forceDynamicProperties, maxPageSize);
        }

        public static object LinqToQuerystring(this IQueryable query, Type inputType, string queryString = "", bool forceDynamicProperties = false, int maxPageSize = -1)
        {
            var queryResult = query;
            var constrainedQuery = query;

            if (query == null)
            {
                throw new ArgumentNullException("query", "Query cannot be null");
            }

            if (queryString == null)
            {
                throw new ArgumentNullException("queryString", "Query String cannot be null");
            }

            if (queryString.StartsWith("?"))
            {
                queryString = queryString.Substring(1);
            }

            var odataQueries = queryString.Split('&').Where(o => o.StartsWith("$")).ToList();
            if (maxPageSize > 0)
            {
                var top = odataQueries.FirstOrDefault(o => o.StartsWith("$top"));
                if (top != null)
                {
                    int pagesize;
                    if (!int.TryParse(top.Split('=')[1], out pagesize) || pagesize >= maxPageSize)
                    {
                        odataQueries.Remove(top);
                        odataQueries.Add("$top=" + maxPageSize);
                    }
                }
                else
                {
                    odataQueries.Add("$top=" + maxPageSize);
                }
            }

            var odataQuerystring = Uri.UnescapeDataString(string.Join("&", odataQueries.ToArray()));

            var input = new ANTLRReaderStream(new StringReader(odataQuerystring));
            var lexer = new LinqToQuerystringLexer(input);
            var tokStream = new CommonTokenStream(lexer);

            var parser = new LinqToQuerystringParser(tokStream) { TreeAdaptor = new TreeNodeFactory(inputType, forceDynamicProperties) };

            var result = parser.prog();

            var singleNode = result.Tree as TreeNode;
            if (singleNode != null && !(singleNode is IdentifierNode))
            {
                if (!(singleNode is SelectNode) && !(singleNode is InlineCountNode))
                {
                    BuildQuery(singleNode, ref queryResult, ref constrainedQuery);
                    return constrainedQuery;
                }

                if (singleNode is SelectNode)
                {
                    return ProjectQuery(constrainedQuery, singleNode);
                }

                return PackageResults(queryResult, constrainedQuery);
            }

            var tree = result.Tree as CommonTree;
            if (tree != null)
            {
                var children = tree.Children.Cast<TreeNode>().ToList();
                children.Sort();

                // These should always come first
                foreach (var node in children.Where(o => !(o is SelectNode) && !(o is InlineCountNode)))
                {
                    BuildQuery(node, ref queryResult, ref constrainedQuery);
                }

                var selectNode = children.FirstOrDefault(o => o is SelectNode);
                if (selectNode != null)
                {
                    constrainedQuery = ProjectQuery(constrainedQuery, selectNode);
                }

                var inlineCountNode = children.FirstOrDefault(o => o is InlineCountNode);
                if (inlineCountNode != null)
                {
                    return PackageResults(queryResult, constrainedQuery);
                }
            }

            return constrainedQuery;
        }

        private static void BuildQuery(TreeNode node, ref IQueryable queryResult, ref IQueryable constrainedQuery)
        {
            var type = queryResult.Provider.GetType().Name;

            var mappings = (!string.IsNullOrEmpty(type) && Configuration.CustomNodes.ContainsKey(type))
                               ? Configuration.CustomNodes[type]
                               : null;

            if (mappings != null)
            {
                node = mappings.MapNode(node, queryResult.Expression);
            }

            if (!(node is TopNode) && !(node is SkipNode))
            {
                var modifier = node as QueryModifier;
                if (modifier != null)
                {
                    queryResult = modifier.ModifyQuery(queryResult);
                }
                else
                {
                    queryResult = queryResult.Provider.CreateQuery(
                        node.BuildLinqExpression(queryResult, queryResult.Expression));
                }
            }

            var queryModifier = node as QueryModifier;
            if (queryModifier != null)
            {
                constrainedQuery = queryModifier.ModifyQuery(constrainedQuery);
            }
            else
            {
                constrainedQuery =
                    constrainedQuery.Provider.CreateQuery(
                        node.BuildLinqExpression(constrainedQuery, constrainedQuery.Expression));
            }
        }

        private static IQueryable ProjectQuery(IQueryable constrainedQuery, TreeNode node)
        {
            // TODO: Find a solution to the following:
            // Currently the only way to perform the SELECT part of the query is to call ToList and then project onto a dictionary. Two main problems:
            // 1. Linq to Entities does not support projection onto list initialisers with more than one value
            // 2. We cannot build an anonymous type using expression trees as there is compiler magic that must happen.
            // There is a solution involving reflection.emit, but is it worth it? Not sure...

            var result = constrainedQuery.GetEnumeratedQuery().AsQueryable();
            return
                result.Provider.CreateQuery<Dictionary<string, object>>(
                    node.BuildLinqExpression(result, result.Expression));

        }

        private static object PackageResults(IQueryable query, IQueryable constrainedQuery)
        {
            var result = query.GetEnumeratedQuery();
            return new Dictionary<string, object> { { "Count", result.Count() }, { "Results", constrainedQuery } };
        }

        public static IEnumerable<object> GetEnumeratedQuery(this IQueryable query)
        {
            return Iterate(query.GetEnumerator()).Cast<object>().ToList();
        }

        static IEnumerable Iterate(this IEnumerator iterator)
        {
            while (iterator.MoveNext())
                yield return iterator.Current;
        }
    }
}