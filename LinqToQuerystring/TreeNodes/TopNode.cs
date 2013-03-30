namespace LinqToQuerystring.TreeNodes
{
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class TopNode : SingleChildNode
    {
        public TopNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression<T>(IQueryable query, Expression expression, Expression item = null)
        {
            return Expression.Call(
                typeof(Queryable),
                "Take",
                new[] { query.ElementType },
                query.Expression,
                this.ChildNode.BuildLinqExpression<T>(query, expression));
        }

        public override int CompareTo(TreeNode other)
        {
            if (other is SkipNode)
            {
                return 1;
            }

            return 0;
        }
    }
}