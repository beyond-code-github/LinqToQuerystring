namespace LinqToQuerystring.TreeNodes.Base
{
    using System;
    using System.Linq;

    using Antlr.Runtime;

    public abstract class SingleChildNode : TreeNode
    {
        protected SingleChildNode(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
        }

        public TreeNode ChildNode
        {
            get
            {
                var childNode = this.ChildNodes.FirstOrDefault();
                if (childNode == null)
                {
                    throw new InvalidOperationException(string.Format("No valid child for {0}", this.GetType()));
                }

                return childNode;
            }
        }
    }
}