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
                return CreateQuery(queryResult, singleNode);
            }

            var tree = result.Tree as CommonTree;
            if (tree != null)
            {
                var children = tree.Children.Cast<TreeNode>().ToList();
                children.Sort();

                foreach (var node in children)
                {
                    queryResult = CreateQuery(queryResult, node);
                }
            }

            return queryResult;
        }

        private static IQueryable CreateQuery(IQueryable query, TreeNode node)
        {
            if (node is OrderByNode)
            {
                var children = node.Children.Cast<ExplicitOrderByBase>();

                if (!query.Provider.GetType().Name.Contains("DbQueryProvider"))
                {
                    children = children.Reverse();
                }

                var explicitOrderByNodes = children as IList<ExplicitOrderByBase> ?? children.ToList();
                explicitOrderByNodes.First().IsFirstChild = true;

                foreach (var child in explicitOrderByNodes)
                {
                    query = query.Provider.CreateQuery(child.BuildLinqExpression(query, query.Expression));
                }
            }
            else
            {
                // TODO: Find a solution to the following:
                // Currently the only way to perform the SELECT part of the query is to call ToList and then project onto a dictionary. Two main problems:
                // 1. Linq to Entities does not support projection onto list initialisers with more than one value
                // 2. We cannot build an anonymous type using expression trees as there is compiler magic that must happen.
                // There is a solution involving reflection.emit, but is it worth it? Not sure...

                // There should only be one of these
                if (node is SelectNode)
                {
                    var result = Iterate(query.GetEnumerator()).Cast<object>().ToList().AsQueryable();
                    return result.Provider.CreateQuery<Dictionary<string, object>>(node.BuildLinqExpression(result, result.Expression));
                }

                query = query.Provider.CreateQuery(node.BuildLinqExpression(query, query.Expression));
            }

            return query;
        }

        static IEnumerable Iterate(this IEnumerator iterator)
        {
            while (iterator.MoveNext())
                yield return iterator.Current;
        }
    }
}