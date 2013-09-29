namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class IgnoredNode : TreeNode
    {
        public IgnoredNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }
        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            return expression;
        }
    }
}
