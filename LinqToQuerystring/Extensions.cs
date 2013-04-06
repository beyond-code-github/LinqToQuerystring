namespace LinqToQuerystring
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;
    using Antlr.Runtime.Tree;

    using LinqToQuerystring.TreeNodes;
    using LinqToQuerystring.TreeNodes.Base;

    public static class Extensions
    {
        public static IQueryable<TResult> ExtendFromOData<T, TResult>(this IQueryable<T> query, string queryString)
        {
            return (IQueryable<TResult>)ExtendFromOData(query, queryString, typeof(T));
        }

        public static IQueryable<T> ExtendFromOData<T>(this IQueryable<T> query, string queryString)
        {
            return (IQueryable<T>)ExtendFromOData(query, queryString, typeof(T));
        }

        public static IQueryable ExtendFromOData(this IQueryable query, string queryString, Type inputType)
        {
            IQueryable queryResult = query;
            IQueryable constrainedQuery = query;

            if (query == null)
            {
                throw new ArgumentNullException("query", "Query cannot be null");
            }

            if (queryString == null)
            {
                throw new ArgumentNullException("querystring", "Query String cannot be null");
            }

            if (queryString.StartsWith("?"))
            {
                queryString = queryString.Substring(1);
            }

            var odataQueries = string.Join(
                "&", queryString.Split('&').Where(o => o.StartsWith("$")));

            var input = new ANTLRReaderStream(new StringReader(odataQueries));
            var lexer = new LinqToQuerystringLexer(input);
            var tokStream = new CommonTokenStream(lexer);

            var parser = new LinqToQuerystringParser(tokStream) { TreeAdaptor = new TreeNodeFactory(inputType) };

            var result = parser.prog();

            var singleNode = result.Tree as TreeNode;
            if (singleNode != null && !(singleNode is IdentifierNode))
            {
                if (!(singleNode is SelectNode) && !(singleNode is InlineCountNode))
                {
                    BuildQuery(singleNode, ref queryResult, ref constrainedQuery);
                    return constrainedQuery;
                }

                return ProjectQuery(queryResult, constrainedQuery, singleNode);
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

                // These should always come last
                foreach (var node in children.Where(o => (o is SelectNode) || (o is InlineCountNode)))
                {
                    constrainedQuery = ProjectQuery(queryResult, constrainedQuery, node);
                }
            }

            return constrainedQuery;
        }

        private static void BuildQuery(TreeNode node, ref IQueryable queryResult, ref IQueryable constrainedQuery)
        {
            if (!(node is TopNode) && !(node is SkipNode))
            {
                if (node is OrderByNode)
                {
                    queryResult = ApplyOrderBy(queryResult, node);
                }
                else
                {
                    queryResult = queryResult.Provider.CreateQuery(
                        node.BuildLinqExpression(queryResult, queryResult.Expression));
                }
            }

            if (node is OrderByNode)
            {
                constrainedQuery = ApplyOrderBy(constrainedQuery, node);
            }
            else
            {
                constrainedQuery =
                    constrainedQuery.Provider.CreateQuery(
                        node.BuildLinqExpression(constrainedQuery, constrainedQuery.Expression));
            }
        }

        private static IQueryable ApplyOrderBy(IQueryable query, TreeNode node)
        {
            var queryresult = query;
            var orderbyChildren = node.Children.Cast<ExplicitOrderByBase>();

            if (!queryresult.Provider.GetType().Name.Contains("DbQueryProvider"))
            {
                orderbyChildren = orderbyChildren.Reverse();
            }

            var explicitOrderByNodes = orderbyChildren as IList<ExplicitOrderByBase> ?? orderbyChildren.ToList();
            explicitOrderByNodes.First().IsFirstChild = true;

            foreach (var child in explicitOrderByNodes)
            {
                queryresult = queryresult.Provider.CreateQuery(child.BuildLinqExpression(queryresult, queryresult.Expression));
            }

            return queryresult;
        }

        private static IQueryable ProjectQuery(IQueryable query, IQueryable constrainedQuery, TreeNode node)
        {
            // TODO: Find a solution to the following:
            // Currently the only way to perform the SELECT part of the query is to call ToList and then project onto a dictionary. Two main problems:
            // 1. Linq to Entities does not support projection onto list initialisers with more than one value
            // 2. We cannot build an anonymous type using expression trees as there is compiler magic that must happen.
            // There is a solution involving reflection.emit, but is it worth it? Not sure...

            // There should only be one of these
            if (node is SelectNode)
            {
                var result = constrainedQuery.GetEnumeratedQuery().AsQueryable();
                return result.Provider.CreateQuery<Dictionary<string, object>>(node.BuildLinqExpression(result, result.Expression));
            }

            // There should only be one of these too, and it should be the last node
            if (node is InlineCountNode)
            {
                var result = query.GetEnumeratedQuery();
                return new List<Dictionary<string, object>> { new Dictionary<string, object> { { "Count", result.Count() }, { "Results", constrainedQuery } } }.AsQueryable();
            }

            throw new ArgumentException("node is not of the correct type", "node");
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