namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class SelectNode<T> : SingleChildNode<T>
    {
        public SelectNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var parameter = item ?? Expression.Parameter(typeof(T), "o");
            Expression childExpression = expression;

            MethodInfo addMethod = typeof(Dictionary<string, object>).GetMethod("Add");
            var elements = this.Children.Cast<TreeNode<T>>().Select(
                o => Expression.ElementInit(addMethod, Expression.Constant(o.Text), Expression.Convert(o.BuildLinqExpression(query, childExpression, parameter), typeof(object))));

            var newDictionary = Expression.New(typeof(Dictionary<string, object>));
            var init = Expression.ListInit(newDictionary, elements);

            var lambda = Expression.Lambda(init, new[] { parameter as ParameterExpression });
            return Expression.Call(typeof(Queryable), "Select", new[] { query.ElementType, typeof(Dictionary<string, object>) }, query.Expression, lambda);
        }

        public override int CompareTo(TreeNode<T> other)
        {
            // Select clause should always be last
            return 1;
        }
    }
}