namespace LinqToQuerystring.EntityFramework5
{
    using Antlr.Runtime;
    using LinqToQuerystring.TreeNodes;
    using LinqToQuerystring.TreeNodes.Base;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class ExpandNode : QueryModifier
    {
        private List<string> members;

        public ExpandNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
            this.members = new List<string>();
        }

        public override IQueryable ModifyQuery(IQueryable query)
        {
            foreach (var child in this.ChildNodes)
            {
                var parameter = Expression.Parameter(this.inputType, "o");
                var childExpression = child.BuildLinqExpression(query, query.Expression, parameter);

                this.VisitMember(childExpression as MemberExpression);

                if (this.members.Count() > 0)
                {
                    query = query.Include(string.Join(".", this.members));
                    this.members.Clear();
                }
            }

            return query;
        }

        private void VisitMember(MemberExpression expression)
        {
            if (expression == null) return;

            // Add the properties to the list
            this.members.Add(expression.Member.Name);

            // Recurse if the nested expression is a member expression
            if (expression.Expression is System.Linq.Expressions.MemberExpression)
            {
                this.VisitMember((MemberExpression)expression.Expression);
            }
            else
            {
                this.members.Reverse();
            }
        }
    }
}