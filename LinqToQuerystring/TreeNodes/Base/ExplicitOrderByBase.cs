namespace LinqToQuerystring.TreeNodes.Base
{
    using System;

    using Antlr.Runtime;

    public abstract class ExplicitOrderByBase : TreeNode
    {
        protected ExplicitOrderByBase(Type inputType, IToken payload, TreeNodeFactory treeNodeFactory)
            : base(inputType, payload, treeNodeFactory)
        {
            this.IsFirstChild = false;
        }

        public bool IsFirstChild { get; set; }
    }
}