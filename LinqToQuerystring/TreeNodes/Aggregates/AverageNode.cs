namespace LinqToQuerystring.TreeNodes.Aggregates
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class AverageNode : TreeNode
    {
        public AverageNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var property = this.ChildNodes.ElementAt(0).BuildLinqExpression(query, expression, item);
            return Expression.Call(typeof(Enumerable), "Average", null, property);
        }
    }
}
