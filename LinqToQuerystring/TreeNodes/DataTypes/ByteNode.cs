namespace LinqToQuerystring.TreeNodes.DataTypes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class ByteNode : TreeNode
    {
        public ByteNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            return Expression.Constant(Convert.ToByte(this.Text.Replace("0x", string.Empty), 16));
        }
    }
}