namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class OrderByNode : SingleChildNode
    {
        public OrderByNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression<T>(IQueryable query, Expression expression, ParameterExpression item = null)
        {
            var parameter = item ?? Expression.Parameter(typeof(T), "o");
            var childExpression = this.ChildNode.BuildLinqExpression<T>(query, expression, parameter);

            var lambda = Expression.Lambda(childExpression, new[] { parameter });

            if (this.ChildNode is DescNode)
            {
                return Expression.Call(typeof(Queryable), "OrderByDescending", new[] { query.ElementType, childExpression.Type }, query.Expression, lambda);
            }

            return Expression.Call(typeof(Queryable), "OrderBy", new[] { query.ElementType, childExpression.Type }, query.Expression, lambda);
        }
    }
}