namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class OrderByNode : QueryModifier
    {
        public OrderByNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            throw new NotSupportedException(
                "Orderby is just a placeholder and should be handled differently in Extensions.cs");
        }

        public override IQueryable ModifyQuery(IQueryable query)
        {
            var queryresult = query;
            var orderbyChildren = this.Children.Cast<ExplicitOrderByBase>();

            if (!queryresult.Provider.GetType().Name.Contains("DbQueryProvider") && !queryresult.Provider.GetType().Name.Contains("MongoQueryProvider"))
            {
                orderbyChildren = orderbyChildren.Reverse();
            }

            var explicitOrderByNodes = orderbyChildren as IList<ExplicitOrderByBase> ?? orderbyChildren.ToList();
            explicitOrderByNodes.First().IsFirstChild = true;

            foreach (var child in explicitOrderByNodes)
            {
                queryresult = queryresult.Provider.CreateQuery(child.BuildLinqExpression(queryresult, queryresult.Expression));
            }

            return queryresult;
        }

        public override int CompareTo(TreeNode other)
        {
            if (other is OrderByNode)
            {
                return 0;
            }

            if (other is FilterNode || other is ExpandNode)
            {
                return 1;
            }

            return -1;
        }
    }
}