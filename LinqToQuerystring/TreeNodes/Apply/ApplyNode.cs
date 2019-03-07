namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class ApplyNode : SingleChildNode
    {
        public ApplyNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            return ChildNode.BuildLinqExpression(query, expression, item);
        }

        public override int CompareTo(TreeNode other)
        {
            if (other is AggregateNode)
            {
                return 0;
            }

            return -1;
        }
    }
}