namespace LinqToQuerystring.TreeNodes
{
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class TopNode<T> : SingleChildNode<T>
    {
        public TopNode(IToken payload)
            : base(payload)
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

        public override int CompareTo(TreeNode<T> other)
        {
            if (other is SkipNode<T>)
            {
                return 1;
            }

            return 0;
        }
    }
}