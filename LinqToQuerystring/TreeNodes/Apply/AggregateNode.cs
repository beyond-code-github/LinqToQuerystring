using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;

namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class AggregateNode : SingleChildNode
    {
        public AggregateNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var parameter = item ?? Expression.Parameter(inputType, "o");

            var childNodes = this.ChildNodes.ToList();

            var addMethod = typeof(Dictionary<string, object>).GetMethod("Add");

            var elements = new List<ElementInit>();

            for (var i = 0; i < childNodes.Count; i = i + 3)
            {
                var propertyNode = childNodes.ElementAtOrDefault(i);
                var withNode = childNodes.ElementAtOrDefault(i + 1) as WithNode;
                var asNode = childNodes.ElementAtOrDefault(i + 2) as AsNode;

                var property = propertyNode.BuildLinqExpression(query, expression, parameter) as MemberExpression;
                var selector = Expression.Lambda(property, false, Expression.Parameter(inputType, "o"));
                var methodName = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(withNode.ChildNode.Text);
                var element = Expression.ElementInit(addMethod, Expression.Constant(asNode.ChildNode.Text)
                    , Expression.Convert(Expression.Call(typeof(Enumerable), methodName, new [] { inputType }, query.Expression, selector), typeof(object)));

                elements.Add(element);
            }

            var newDictionary = Expression.New(typeof(Dictionary<string, object>));
            var init = Expression.ListInit(newDictionary, elements);

            var lambda = Expression.Lambda(init, new[] { parameter as ParameterExpression });
            return Expression.Call(typeof(Queryable), "Select", new[] { query.ElementType, typeof(Dictionary<string, object>) }, query.Expression, lambda);
        }

        public override int CompareTo(TreeNode other)
        {
            if (other is AggregateNode)
            {
                return 0;
            }

            return -1;
        }
    }
}