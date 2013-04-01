namespace LinqToQuerystring
{
    using System;
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
            return (IQueryable<TResult>)Extend(query, queryString);
        }

        public static IQueryable<T> ExtendFromOData<T>(this IQueryable<T> query, string queryString)
        {
            return (IQueryable<T>)Extend(query, queryString);
        }

        private static IQueryable Extend<T>(IQueryable<T> query, string queryString)
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

            var parser = new LinqToQuerystringParser(tokStream) { TreeAdaptor = new TreeNodeFactory<T>() };

            var result = parser.prog();

            var singleNode = result.Tree as TreeNode<T>;
            if (singleNode != null && !(singleNode is IdentifierNode<T>))
            {
                return CreateQuery<T>(queryResult, singleNode);
            }

            var tree = result.Tree as CommonTree;
            if (tree != null)
            {
                var children = tree.Children.Cast<TreeNode<T>>().ToList();
                children.Sort();

                foreach (var node in children)
                {
                    queryResult = CreateQuery(queryResult, node);
                }
            }

            return queryResult;
        }

        private static IQueryable CreateQuery<T>(IQueryable query, TreeNode<T> node)
        {
            if (node is OrderByNode<T>)
            {
                var children = node.Children.Cast<ExplicitOrderByBase<T>>();

                if (!query.Provider.GetType().Name.Contains("DbQueryProvider"))
                {
                    children = children.Reverse();
                }

                var explicitOrderByNodes = children as IList<ExplicitOrderByBase<T>> ?? children.ToList();
                explicitOrderByNodes.First().IsFirstChild = true;

                foreach (var child in explicitOrderByNodes)
                {
                    query = query.Provider.CreateQuery<T>(child.BuildLinqExpression(query, query.Expression));
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
                if (node is SelectNode<T>)
                {
                    var result = ((IQueryable<T>)query).ToList().AsQueryable();
                    return result.Provider.CreateQuery<Dictionary<string, object>>(node.BuildLinqExpression(result, result.Expression));
                }

                query = query.Provider.CreateQuery<T>(node.BuildLinqExpression(query, query.Expression));
            }

            return query;
        }
    }
}