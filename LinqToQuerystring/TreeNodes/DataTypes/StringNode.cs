namespace LinqToQuerystring.TreeNodes.DataTypes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class StringNode : TreeNode
    {
        public StringNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var text = ExtractText();
            return Expression.Constant(text);
        }

        public override Expression BuildLinqExpressionWithComparison(IQueryable query, Expression expression, Expression item = null,
            Expression compareExpression = null)
        {
            if (compareExpression != null && compareExpression.Type.IsEnum)
            {
                Type enumType = compareExpression.Type;
                var enumValue = Convert.ChangeType(Enum.Parse(enumType, ExtractText(),ignoreCase: true), enumType);
                return Expression.Constant(enumValue);
            }
            return base.BuildLinqExpressionWithComparison(query, expression, item, compareExpression);
        }

        private string ExtractText()
        {
            var text = this.Text.Trim('\'');
            text = text.Replace(@"\\", @"\");
            text = text.Replace(@"\b", "\b");
            text = text.Replace(@"\t", "\t");
            text = text.Replace(@"\n", "\n");
            text = text.Replace(@"\f", "\f");
            text = text.Replace(@"\r", "\r");
            text = text.Replace(@"\'", "'");
            text = text.Replace(@"''", "'");
            return text;
        }
    }
}