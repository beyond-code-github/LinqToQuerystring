namespace LinqToQuerystring.TreeNodes.Base
{
    using System;

    using Antlr.Runtime;

    public abstract class SingleChildNode : TreeNode
    {
        protected SingleChildNode(Type inputType, IToken payload)
            : base(inputType, payload)
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