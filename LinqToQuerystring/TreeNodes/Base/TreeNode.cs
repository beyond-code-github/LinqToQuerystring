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
    }
}