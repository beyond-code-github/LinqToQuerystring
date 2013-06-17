namespace LinqToQuerystring.TreeNodes.Aggregates
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class MinNode : TreeNode
    {
        public MinNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var property = this.ChildNodes.ElementAt(0).BuildLinqExpression(query, expression, item);

            var underlyingType = property.Type;
            if (typeof(IEnumerable).IsAssignableFrom(property.Type) && property.Type.GetGenericArguments().Any())
            {
                underlyingType = property.Type.GetGenericArguments()[0];
            }

            return Expression.Call(typeof(Enumerable), "Min", new[] { underlyingType }, property);
        }
    }
}
