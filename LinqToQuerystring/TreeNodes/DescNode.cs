namespace LinqToQuerystring.TreeNodes
{
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class DescNode : SingleChildNode
    {
        public DescNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression<T>(IQueryable query, Expression expression, ParameterExpression item = null)
        {
            var parameter = item ?? Expression.Parameter(typeof(T), "o");
            var childExpression = this.ChildNode.BuildLinqExpression<T>(query, expression, parameter);

            var lambda = Expression.Lambda(childExpression, new[] { parameter });
            return Expression.Call(typeof(Queryable), "OrderByDescending", new[] { query.ElementType, childExpression.Type }, query.Expression, lambda);
        }
    }
}