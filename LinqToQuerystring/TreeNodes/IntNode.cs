namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class IntNode : TreeNode
    {
        public IntNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression<T>(IQueryable query, Expression expression, ParameterExpression item = null)
        {
            return Expression.Constant(Convert.ToInt32(this.Text));
        }
    }
}