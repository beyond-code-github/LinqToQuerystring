namespace LinqToQuerystring.TreeNodes
{
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class AndNode : TwoChildNode
    {
        public AndNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression<T>(IQueryable query, Expression expression, ParameterExpression item = null)
        {
            return Expression.And(
                this.LeftNode.BuildLinqExpression<T>(query, expression, item),
                this.RightNode.BuildLinqExpression<T>(query, expression, item));
        }
    }
}