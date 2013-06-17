using System;

namespace LinqToQuerystring.TreeNodes.Base
{
    using System.Linq;

    using Antlr.Runtime;

    public abstract class QueryModifier : TreeNode
    {
        protected QueryModifier(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override System.Linq.Expressions.Expression BuildLinqExpression(System.Linq.IQueryable query, System.Linq.Expressions.Expression expression, System.Linq.Expressions.Expression item = null)
        {
            throw new NotSupportedException(
               string.Format("{0} is just a placeholder and should be handled differently in Extensions.cs", this.GetType().Name));
        }

        public abstract IQueryable ModifyQuery(IQueryable query);
    }
}
