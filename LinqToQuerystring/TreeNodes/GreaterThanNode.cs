namespace LinqToQuerystring.TreeNodes
{
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class GreaterThanNode<T> : TwoChildNode<T>
    {
        public GreaterThanNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var leftExpression = this.LeftNode.BuildLinqExpression(query, expression, item);
            var rightExpression = this.RightNode.BuildLinqExpression(query, expression, item);

            if (!leftExpression.Type.IsAssignableFrom(rightExpression.Type))
            {
                rightExpression = Expression.Convert(rightExpression, leftExpression.Type);
            }

            return Expression.GreaterThan(leftExpression, rightExpression);
        }
    }
}