namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class DynamicIdentifierNode : TreeNode
    {
        public DynamicIdentifierNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item)
        {
            var key = this.Text.Trim(new[] { '[', ']' });
            var property = Expression.Call(item, "get_Item", null, Expression.Constant(key));

            var child = this.ChildNodes.FirstOrDefault();
            if (child != null)
            {
                return child.BuildLinqExpression(query, expression, property);
            }

            return property;
        }
    }
}