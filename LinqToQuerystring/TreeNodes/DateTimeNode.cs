namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class DateTimeNode<T> : TreeNode<T>
    {
        public DateTimeNode(IToken payload)
            : base(payload)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var dateText = this.Text
                .Replace("datetime'", string.Empty)
                .Replace("'", string.Empty)
                .Replace(".", ":");

            return Expression.Constant(DateTime.Parse(dateText, null, DateTimeStyles.RoundtripKind));
        }
    }
}