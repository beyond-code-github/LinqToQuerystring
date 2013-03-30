namespace LinqToQuerystring.TreeNodes
{
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class OrNode : TwoChildNode
    {
        public OrNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression<T>(IQueryable query, Expression expression, Expression item = null)
        {
            return Expression.Or(
                this.LeftNode.BuildLinqExpression<T>(query, expression, item),
                this.RightNode.BuildLinqExpression<T>(query, expression, item));
        }
    }
}