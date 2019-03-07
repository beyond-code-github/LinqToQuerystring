using System.Collections.Generic;

namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class ApplyNode : SingleChildNode
    {
        public ApplyNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var result = ChildNode.BuildLinqExpression(query, expression, item);
            foreach (var child in ChildNodes.Skip(1))
            {
                result = child.BuildLinqExpression(query, result, Expression.Parameter(typeof(Dictionary<string, object>)));
            }
            return result;
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