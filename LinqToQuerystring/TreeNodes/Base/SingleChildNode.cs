namespace LinqToQuerystring.TreeNodes.Base
{
    using System;

    using Antlr.Runtime;

    public abstract class SingleChildNode : TreeNode
    {
        protected SingleChildNode(IToken payload)
            : base(payload)
        {
        }

        public TreeNode ChildNode
        {
            get
            {
                var childNode = this.Children[0] as TreeNode;
                if (childNode == null)
                {
                    throw new InvalidOperationException(string.Format("No valid child for {0}", this.GetType()));
                }

                return childNode;
            }
        }
    }
}