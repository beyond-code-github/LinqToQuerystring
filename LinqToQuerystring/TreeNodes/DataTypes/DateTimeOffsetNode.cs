namespace LinqToQuerystring.TreeNodes.DataTypes
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class DateTimeOffsetNode : TreeNode
    {
        public DateTimeOffsetNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var dateText = this.Text
                .Replace("datetimeoffset'", string.Empty)
                .Replace("'", string.Empty);

            return Expression.Constant(DateTime.Parse(dateText, null, DateTimeStyles.AssumeUniversal));
        }
    }
}
