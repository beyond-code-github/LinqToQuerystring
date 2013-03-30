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
        public static IQueryable<T> ExtendFromOData<T>(this IQueryable<T> query, string queryString)
        {
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

            var parser = new LinqToQuerystringParser(tokStream) { TreeAdaptor = new TreeNodeFactory() };

            var result = parser.prog();

            var singleNode = result.Tree as TreeNode;
            if (singleNode != null && !(singleNode is IdentifierNode))
            {
                return CreateQuery(query, singleNode);
            }

            var tree = result.Tree as CommonTree;
            if (tree != null)
            {
                var children = tree.Children.Cast<TreeNode>().ToList();
                children.Sort();

                foreach (var node in children)
                {
                    query = CreateQuery(query, node);
                }
            }

            return query;
        }

        private static IQueryable<T> CreateQuery<T>(IQueryable<T> query, TreeNode node)
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
                    query = query.Provider.CreateQuery<T>(child.BuildLinqExpression<T>(query, query.Expression));
                }
            }
            else
            {
                query = query.Provider.CreateQuery<T>(node.BuildLinqExpression<T>(query, query.Expression));
            }

            return query;
        }
    }
}