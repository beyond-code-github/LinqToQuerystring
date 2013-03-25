namespace LinqToQuerystring.TreeNodes.Base
{
    using System;

    using Antlr.Runtime;

    public abstract class TwoChildNode : TreeNode
    {
        protected TwoChildNode(IToken payload)
            : base(payload)
        {
        }

        public TreeNode LeftNode
        {
            get
            {
                var leftNode = this.Children[0] as TreeNode;
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
                var rightNode = this.Children[1] as TreeNode;
                if (rightNode == null)
                {
                    throw new InvalidOperationException(string.Format("No valid right node for {0}", this.GetType()));
                }

                return rightNode;
            }
        }
    }
}