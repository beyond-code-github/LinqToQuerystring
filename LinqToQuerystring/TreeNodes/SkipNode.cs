namespace LinqToQuerystring.TreeNodes
{
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class SkipNode<T> : SingleChildNode<T>
    {
        public SkipNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            return Expression.Call(typeof(Queryable), "Skip", new[] { query.ElementType }, query.Expression, this.ChildNode.BuildLinqExpression(query, expression));
        }

        public override int CompareTo(TreeNode<T> other)
        {
            if (other is TopNode<T>)
            {
                return -1;
            }

            if (other is OrderByNode<T>)
            {
                return 1;
            }

            return 0;
        }
    }
}