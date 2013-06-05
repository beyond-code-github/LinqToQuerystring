namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class NotNode : SingleChildNode
    {
        public NotNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var childExpression = this.ChildNode.BuildLinqExpression(query, expression, item);
            if (!typeof(bool).IsAssignableFrom(childExpression.Type))
            {
                childExpression = Expression.Convert(childExpression, typeof(bool));
            }

            return Expression.Not(childExpression);
        }
    }
}