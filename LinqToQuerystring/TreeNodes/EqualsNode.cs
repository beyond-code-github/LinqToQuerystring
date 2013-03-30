namespace LinqToQuerystring.TreeNodes
{
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class EqualsNode : TwoChildNode
    {
        public EqualsNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression<T>(IQueryable query, Expression expression, Expression item = null)
        {
            var leftExpression = this.LeftNode.BuildLinqExpression<T>(query, expression, item);
            var rightExpression = this.RightNode.BuildLinqExpression<T>(query, expression, item);

            if (!leftExpression.Type.IsAssignableFrom(rightExpression.Type))
            {
                rightExpression = Expression.Convert(rightExpression, leftExpression.Type);
            }

            return Expression.Equal(leftExpression, rightExpression);
        }
    }
}