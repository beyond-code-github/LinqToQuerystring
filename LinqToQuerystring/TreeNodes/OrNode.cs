namespace LinqToQuerystring.TreeNodes
{
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class OrNode<T> : TwoChildNode<T>
    {
        public OrNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            return Expression.Or(
                this.LeftNode.BuildLinqExpression(query, expression, item),
                this.RightNode.BuildLinqExpression(query, expression, item));
        }
    }
}