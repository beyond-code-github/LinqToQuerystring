namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class FilterNode : SingleChildNode
    {
        public FilterNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var parameter = item ?? Expression.Parameter(inputType, "o");
            var lambda = Expression.Lambda(
                this.ChildNode.BuildLinqExpression(query, expression, parameter), new[] { parameter as ParameterExpression });

            return Expression.Call(typeof(Queryable), "Where", new[] { query.ElementType }, query.Expression, lambda);
        }

        public override int CompareTo(TreeNode other)
        {
            if (other is FilterNode)
            {
                return 0;
            }

            return -1;
        }
    }
}