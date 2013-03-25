namespace LinqToQuerystring
{
    using System;
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
                if (singleNode is OrderByNode)
                {
                    foreach (var child in singleNode.Children.Cast<TreeNode>().Reverse())
                    {
                        query = query.Provider.CreateQuery<T>(child.BuildLinqExpression<T>(query, query.Expression));
                    }
                }
                else
                {
                    query = query.Provider.CreateQuery<T>(singleNode.BuildLinqExpression<T>(query, query.Expression));
                }

                return query;
            }

            var tree = result.Tree as CommonTree;
            if (tree != null)
            {
                var children = tree.Children.Cast<TreeNode>().ToList();
                children.Sort();

                foreach (var baseNode in children)
                {
                    query = query.Provider.CreateQuery<T>(baseNode.BuildLinqExpression<T>(query, query.Expression));
                }
            }

            return query;
        }
    }
}