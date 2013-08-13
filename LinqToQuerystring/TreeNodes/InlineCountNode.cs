namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class InlineCountNode : SingleChildNode
    {
        public InlineCountNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            throw new NotSupportedException(
                "InlineCountNode is just a placeholder and should be handled differently in Extensions.cs");
        }

        public override int CompareTo(TreeNode other)
        {
            if (other is InlineCountNode)
            {
                return 0;
            }

            return 1;
        }
    }
}