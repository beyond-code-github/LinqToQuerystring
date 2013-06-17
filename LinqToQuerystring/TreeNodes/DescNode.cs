namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class DescNode : ExplicitOrderByBase
    {
        public DescNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var parameter = item ?? Expression.Parameter(inputType, "o");
            Expression childExpression = expression;

            var temp = parameter;

            foreach (var child in this.ChildNodes.Cast<TreeNode>())
            {
                childExpression = child.BuildLinqExpression(query, childExpression, temp);
                temp = childExpression;
            }

            Debug.Assert(childExpression != null, "childExpression should never be null");

            var methodName = "OrderByDescending";
            if ((query.Provider.GetType().Name.Contains("DbQueryProvider") || query.Provider.GetType().Name.Contains("MongoQueryProvider")) && !this.IsFirstChild)
            {
                methodName = "ThenByDescending";
            }

            var lambda = Expression.Lambda(childExpression, new[] { parameter as ParameterExpression });
            return Expression.Call(typeof(Queryable), methodName, new[] { query.ElementType, childExpression.Type }, query.Expression, lambda);
        }
    }
}