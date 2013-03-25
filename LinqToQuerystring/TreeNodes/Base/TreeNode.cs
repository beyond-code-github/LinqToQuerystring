namespace LinqToQuerystring.TreeNodes.Base
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;
    using Antlr.Runtime.Tree;

    public abstract class TreeNode : CommonTree, IComparable<TreeNode>
    {
        protected TreeNode(IToken payload)
            : base(payload)
        {
        }

        public abstract Expression BuildLinqExpression<T>(
            IQueryable query, Expression expression, ParameterExpression item = null);

        public virtual int CompareTo(TreeNode other)
        {
            return 0;
        }
    }
}