namespace LinqToQuerystring.TreeNodes.Base
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;
    using Antlr.Runtime.Tree;

    public abstract class TreeNode<T> : CommonTree, IComparable<TreeNode<T>>
    {
        protected TreeNode(IToken payload)
            : base(payload)
        {
        }

        public abstract Expression BuildLinqExpression(
            IQueryable query, Expression expression, Expression item = null);

        public virtual int CompareTo(TreeNode<T> other)
        {
            return 0;
        }
    }
}