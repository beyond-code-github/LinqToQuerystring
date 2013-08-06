namespace LinqToQuerystring.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes;
    using LinqToQuerystring.TreeNodes.Base;

    public class ExpandNode : QueryModifier
    {
        public ExpandNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override IQueryable ModifyQuery(IQueryable query)
        {
            foreach (var child in this.ChildNodes)
            {
                var parameter = Expression.Parameter(this.inputType, "o");
                var childExpression = child.BuildLinqExpression(query, query.Expression, parameter);

                var member = childExpression as MemberExpression;
                query = query.Include(member.Member.Name);
            }

            return query;
        }
    }
}