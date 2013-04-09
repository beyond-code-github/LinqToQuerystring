namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class DynamicIdentifierNode : TreeNode
    {
        public DynamicIdentifierNode(Type inputType, IToken payload)
            : base(inputType, payload)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item)
        {
            var key = this.Text.Trim(new[] { '[', ']' });
            return Expression.Call(item, "get_Item", null, Expression.Constant(key));
        }
    }
}