namespace LinqToQuerystring.TreeNodes.Base
{
    using System;
    using System.Linq;

    using Antlr.Runtime;

    public abstract class TwoChildNode : TreeNode
    {
        protected TwoChildNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public TreeNode LeftNode
        {
            get
            {
                var leftNode = this.ChildNodes.ElementAtOrDefault(0);
                if (leftNode == null)
                {
                    throw new InvalidOperationException(string.Format("No valid left node for {0}", this.GetType()));
                }

                return leftNode;
            }
        }

        public TreeNode RightNode
        {
            get
            {
                var rightNode = this.ChildNodes.ElementAtOrDefault(1);
                if (rightNode == null)
                {
                    throw new InvalidOperationException(string.Format("No valid right node for {0}", this.GetType()));
                }

                return rightNode;
            }
        }
    }
}