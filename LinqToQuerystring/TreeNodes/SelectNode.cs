using System.Text;

namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    public class SelectNode : SingleChildNode
    {
        public SelectNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var fixedexpr = Expression.Call(typeof(Queryable), "Cast", new[] { inputType }, query.Expression);

            query = query.Provider.CreateQuery(fixedexpr);

            var parameter = item ?? Expression.Parameter(inputType, "o");
            Expression childExpression = fixedexpr;

            MethodInfo addMethod = typeof(Dictionary<string, object>).GetMethod("Add");

            var childrenNodes = ChildNodes.ToList();

            var elements = new List<ElementInit>();

            for (var i = 0; i < childrenNodes.Count;)
            {
                var next = i + 1;
                var node = childrenNodes[i];
                AsNode asNode = null;

                var nameToUse = GetUniquePropertyName(node);

                if (next < childrenNodes.Count)
                {
                    asNode = childrenNodes[next] as AsNode;
                    if (asNode != null)
                    {
                        nameToUse = asNode.ChildNode.Text;
                    }
                }

                var element = Expression.ElementInit(addMethod, Expression.Constant(nameToUse)
                                , Expression.Convert(node.BuildLinqExpression(query, childExpression, parameter), typeof(object)));

                elements.Add(element);

                if (asNode == null)
                {
                    i++;
                }
                else
                {
                    i = i + 2;
                }
            }
            
            //var elements = this.ChildNodes.Select(
            //    o => Expression.ElementInit(addMethod, Expression.Constant(GetUniquePropertyName(o))
            //        , Expression.Convert(o.BuildLinqExpression(query, childExpression, parameter), typeof(object))));

            var newDictionary = Expression.New(typeof(Dictionary<string, object>));
            var init = Expression.ListInit(newDictionary, elements);

            var lambda = Expression.Lambda(init, new[] { parameter as ParameterExpression });
            return Expression.Call(typeof(Queryable), "Select", new[] { query.ElementType, typeof(Dictionary<string, object>) }, query.Expression, lambda);
        }

        private string GetUniquePropertyName(TreeNode node)
        {
            var builder = new StringBuilder(node.Text);
            if (node.Children != null && node.Children.Any())
            {
                builder.Append("_");
                builder.Append(GetUniquePropertyName(node.Children.First() as TreeNode));
            }
            return builder.ToString();
        }

        public override int CompareTo(TreeNode other)
        {
            if (other is SelectNode)
            {
                return 0;
            }

            // Select clause should always be last apart from inlinecount
            if (other is InlineCountNode)
            {
                return -1;
            }

            return 1;
        }
    }
}