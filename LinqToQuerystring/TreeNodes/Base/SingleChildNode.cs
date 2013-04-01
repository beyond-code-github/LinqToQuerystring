namespace LinqToQuerystring.TreeNodes.Base
{
    using System;

    using Antlr.Runtime;

    public abstract class SingleChildNode<T> : TreeNode<T>
    {
        protected SingleChildNode(IToken payload)
            : base(payload)
        {
        }

        public TreeNode<T> ChildNode
        {
            get
            {
                var childNode = this.Children[0] as TreeNode<T>;
                if (childNode == null)
                {
                    throw new InvalidOperationException(string.Format("No valid child for {0}", this.GetType()));
                }

                return childNode;
            }
        }
    }
}