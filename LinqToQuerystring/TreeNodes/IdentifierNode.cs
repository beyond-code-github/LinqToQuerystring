namespace LinqToQuerystring.TreeNodes
{
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class IdentifierNode : TreeNode
    {
        public IdentifierNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression<T>(IQueryable query, Expression expression, ParameterExpression item)
        {
            //return Expression.Call(item, "get_Item", null, Expression.Constant(this.Text));
            return Expression.Property(item, this.Text);
        }
    }
}