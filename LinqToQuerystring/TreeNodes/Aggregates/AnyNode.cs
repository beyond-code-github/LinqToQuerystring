namespace LinqToQuerystring.TreeNodes.Aggregates
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class AnyNode : TreeNode
    {
        public AnyNode(Type inputType, IToken payload)
            : base(inputType, payload)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var property = ((TreeNode)Children[0]).BuildLinqExpression(query, expression, item);
            var alias = Children[1].Text;
            var filter = ((TreeNode)Children[2]);

            var underlyingType = property.Type.GetGenericArguments()[0];
            var parameter = Expression.Parameter(underlyingType, alias);

            var lambda = Expression.Lambda(
                filter.BuildLinqExpression(query, expression, parameter), new[] { parameter });

            return Expression.Call(typeof(Enumerable), "Any", new[] { underlyingType }, property, lambda);
        }
    }
}
