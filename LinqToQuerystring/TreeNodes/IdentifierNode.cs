namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class IdentifierNode : TreeNode
    {
        public IdentifierNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item)
        {
            var property = Expression.Property(item, this.Text);

            var child = this.ChildNodes.FirstOrDefault();
            if (child != null)
            {
                return child.BuildLinqExpression(query, expression, property);
            }

            return property;
        }
    }
}