namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class GreaterThanOrEqualNode : TwoChildNode
    {
        public GreaterThanOrEqualNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
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

            if (!rightExpression.Type.IsAssignableFrom(leftExpression.Type))
            {
                leftExpression = Expression.Convert(leftExpression, rightExpression.Type);
            }

            return Expression.GreaterThanOrEqual(leftExpression, rightExpression);
        }
    }
}