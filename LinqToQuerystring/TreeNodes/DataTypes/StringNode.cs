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
            var text = this.Text.Trim('\'');
            text = text.Replace(@"\\", @"\");
            text = text.Replace(@"\b", "\b");
            text = text.Replace(@"\t", "\t");
            text = text.Replace(@"\n", "\n");
            text = text.Replace(@"\f", "\f");
            text = text.Replace(@"\r", "\r");
            text = text.Replace(@"\'", "'");
            text = text.Replace(@"''", "'");

            return Expression.Constant(text);
        }
    }
}