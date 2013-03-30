namespace LinqToQuerystring.TreeNodes
{
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class AscNode : TreeNode
    {
        public AscNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression<T>(IQueryable query, Expression expression, Expression item = null)
        {
            var parameter = item ?? Expression.Parameter(typeof(T), "o");
            Expression childExpression = expression;

            var temp = parameter;

            foreach (var child in this.Children.Cast<TreeNode>())
            {
                childExpression = child.BuildLinqExpression<T>(query, childExpression, temp);
                temp = childExpression;
            }

            Debug.Assert(childExpression != null, "childExpression should never be null");

            var lambda = Expression.Lambda(childExpression, new[] { parameter as ParameterExpression });
            return Expression.Call(typeof(Queryable), "OrderBy", new[] { query.ElementType, childExpression.Type }, query.Expression, lambda);
        }
    }
}