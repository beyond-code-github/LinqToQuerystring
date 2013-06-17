namespace LinqToQuerystring.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes;
    using LinqToQuerystring.TreeNodes.Base;

    public class CustomNodeMappings : Dictionary<int, Func<Type, IToken, TreeNodeFactory, TreeNode>>
    {
        public TreeNode MapNode(TreeNode node, Expression expression)
        {
            if (this.ContainsKey(node.Type))
            {
                var mappedNode = this[node.Type](node.inputType, node.payload, node.factory);
                mappedNode.AddChildren(node.Children);
                return mappedNode;
            }

            return node;
        }
    }
}
