namespace LinqToQuerystring.TreeNodes
{
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class IdentifierNode<T> : TreeNode<T>
    {
        public IdentifierNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item)
        {
            //return Expression.Call(item, "get_Item", null, Expression.Constant(this.Text));
            return Expression.Property(item, this.Text);
        }
    }
}