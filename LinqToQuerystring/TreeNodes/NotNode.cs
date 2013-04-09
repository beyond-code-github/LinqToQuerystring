namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class NotNode : SingleChildNode
    {
        public NotNode(Type inputType, IToken payload)
            : base(inputType, payload)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            if (typeof(bool).IsAssignableFrom(expression.Type))
            {
                expression = Expression.Convert(expression, typeof(bool));
            }

            return Expression.Not(this.ChildNode.BuildLinqExpression(query, expression, item));
        }
    }
}