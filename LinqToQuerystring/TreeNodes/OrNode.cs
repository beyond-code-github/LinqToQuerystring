namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class OrNode : TwoChildNode
    {
        public OrNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            return Expression.OrElse(
                this.LeftNode.BuildLinqExpression(query, expression, item),
                this.RightNode.BuildLinqExpression(query, expression, item));
        }
    }
}