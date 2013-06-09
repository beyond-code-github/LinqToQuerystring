namespace LinqToQuerystring.TreeNodes.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;
    using Antlr.Runtime.Tree;

    public abstract class TreeNode : CommonTree, IComparable<TreeNode>
    {
        protected readonly Type inputType;

        protected readonly TreeNodeFactory factory;

        protected TreeNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(payload)
        {
            this.inputType = inputType;
            this.factory = treeNodeFactory;
        }

        /// <summary>
        /// This hacky property overwrites the base property which has a bug when using tree rewrites
        /// </summary>
        protected new IEnumerable<TreeNode> Children
        {
            get
            {
                var result = new List<TreeNode>();
                if (base.ChildCount <= 0)
                {
                    return result;
                }

                foreach (var child in base.Children)
                {
                    var node = child as TreeNode;
                    if (node == null)
                    {
                        node = (TreeNode)this.factory.Create(new CommonToken(child.Type, child.Text));
                        var tree = child as CommonTree;
                        if (tree != null)
                        {
                            node.AddChildren(tree.Children);
                        }
                    }

                    result.Add(node);
                }

                return result;
            }
        }

        public abstract Expression BuildLinqExpression(
            IQueryable query, Expression expression, Expression item = null);

        public virtual int CompareTo(TreeNode other)
        {
            return 0;
        }

        protected static void NormalizeTypes(ref Expression leftSide, ref Expression rightSide)
        {
            var rightSideIsConstant = rightSide is ConstantExpression;
            var leftSideIsConstant = leftSide is ConstantExpression;

            if (rightSideIsConstant && leftSideIsConstant)
            {
                return;
            }

            if (rightSideIsConstant)
            {
                // If we are comparing to an object try to cast it to the same type as the constant
                if (leftSide.Type == typeof(object))
                {
                    leftSide = MapAndCast(leftSide, rightSide);
                }
                else
                {
                    rightSide = MapAndCast(rightSide, leftSide);
                }
            }

            if (leftSideIsConstant)
            {
                // If we are comparing to an object try to cast it to the same type as the constant
                if (rightSide.Type == typeof(object))
                {
                    rightSide = MapAndCast(rightSide, leftSide);
                }
                else
                {
                    leftSide = MapAndCast(leftSide, rightSide);
                }
            }
        }

        private static Expression MapAndCast(Expression from, Expression to)
        {
            var mapped = Configuration.TypeConversionMap(from.Type, to.Type);
            if (mapped != from.Type)
            {
                from = CastIfNeeded(from, mapped);
            }

            return CastIfNeeded(from, to.Type);
        }

        protected static Expression CastIfNeeded(Expression expression, Type type)
        {
            var converted = expression;
            if (!type.IsAssignableFrom(expression.Type))
            {
                var convertToType = Configuration.TypeConversionMap(expression.Type, type);
                converted = Expression.Convert(expression, convertToType);
            }

            return converted;
        }
    }
}