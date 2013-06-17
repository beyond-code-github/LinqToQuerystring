namespace LinqToQuerystring.TreeNodes.Aggregates
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class CountNode : TreeNode
    {
        public CountNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
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
            else
            {
                //We will sometimes need to cater for special cases here, such as Enumerating BsonValues
                underlyingType = Configuration.EnumerableTypeMap(underlyingType);
                var enumerable = typeof(IEnumerable<>).MakeGenericType(underlyingType);
                property = Expression.Convert(property, enumerable);
            }

            return Expression.Call(typeof(Enumerable), "Count", new[] { underlyingType }, property);
        }
    }
}
