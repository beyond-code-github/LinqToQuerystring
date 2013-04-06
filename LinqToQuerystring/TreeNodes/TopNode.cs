namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class TopNode : SingleChildNode
    {
        public TopNode(Type inputType, IToken payload)
            : base(inputType, payload)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            return Expression.Call(
                typeof(Queryable),
                "Take",
                new[] { query.ElementType },
                query.Expression,
                this.ChildNode.BuildLinqExpression(query, expression));
        }

        public override int CompareTo(TreeNode other)
        {
            if (other is OrderByNode || other is FilterNode || other is SkipNode)
            {
                return 1;
            }

            return -1;
        }
    }
}