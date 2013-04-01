namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class OrderByNode : SingleChildNode
    {
        public OrderByNode(Type inputType, IToken payload)
            : base(inputType, payload)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            throw new NotSupportedException(
                "Orderby is just a placeholder and should be handled differently in Extensions.cs");
        }

        public override int CompareTo(TreeNode other)
        {
            if (other is SkipNode)
            {
                return -1;
            }

            return 0;
        }
    }
}