namespace LinqToQuerystring.TreeNodes.Base
{
    using Antlr.Runtime;

    public abstract class ExplicitOrderByBase : TreeNode
    {
        protected ExplicitOrderByBase(IToken payload)
            : base(payload)
        {
            this.IsFirstChild = false;
        }

        public bool IsFirstChild { get; set; }
    }
}