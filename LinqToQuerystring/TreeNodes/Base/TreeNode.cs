namespace LinqToQuerystring.TreeNodes.Base
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;
    using Antlr.Runtime.Tree;

    public abstract class TreeNode : CommonTree, IComparable<TreeNode>
    {
        protected readonly Type inputType;

        protected TreeNode(Type inputType, IToken payload)
            : base(payload)
        {
            this.inputType = inputType;
        }

        public abstract Expression BuildLinqExpression(
            IQueryable query, Expression expression, Expression item = null);

        public virtual int CompareTo(TreeNode other)
        {
            return 0;
        }
    }
}