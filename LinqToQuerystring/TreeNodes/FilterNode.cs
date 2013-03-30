namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class FilterNode : SingleChildNode
    {
        public FilterNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression<T>(IQueryable query, Expression expression, Expression item = null)
        {
            var parameter = item ?? Expression.Parameter(typeof(T), "o");
            var lambda = Expression.Lambda<Func<T, bool>>(
                this.ChildNode.BuildLinqExpression<T>(query, expression, parameter), new[] { parameter as ParameterExpression });

            return Expression.Call(typeof(Queryable), "Where", new[] { query.ElementType }, query.Expression, lambda);
        }
    }
}