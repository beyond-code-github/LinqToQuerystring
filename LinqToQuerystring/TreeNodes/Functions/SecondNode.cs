namespace LinqToQuerystring.TreeNodes.Functions
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.Exceptions;
    using LinqToQuerystring.TreeNodes.Base;

    public class SecondNode : SingleChildNode
    {
        public SecondNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var childexpression = this.ChildNode.BuildLinqExpression(query, expression, item);

            if (!typeof(DateTime).IsAssignableFrom(childexpression.Type) && !typeof(DateTimeOffset).IsAssignableFrom(childexpression.Type))
            {
                throw new FunctionNotSupportedException(childexpression.Type, "second");
            }

            return Expression.Property(childexpression, "Second");
        }
    }
}