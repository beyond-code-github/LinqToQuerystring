namespace LinqToQuerystring.TreeNodes
{
    using System;

    using Antlr.Runtime.Tree;

    using LinqToQuerystring.TreeNodes.Functions;

    public class TreeNodeFactory : CommonTreeAdaptor
    {
        private readonly Type inputType;

        public TreeNodeFactory(Type inputType)
        {
            this.inputType = inputType;
        }

        public override object Create(Antlr.Runtime.IToken token)
        {
            if (token == null)
            {
                return new CommonTree();
            }

            switch (token.Type)
            {
                case LinqToQuerystringLexer.TOP:
                    return new TopNode(inputType, token);
                case LinqToQuerystringLexer.SKIP:
                    return new SkipNode(inputType, token);
                case LinqToQuerystringLexer.ORDERBY:
                    return new OrderByNode(inputType, token);
                case LinqToQuerystringLexer.FILTER:
                    return new FilterNode(inputType, token);
                case LinqToQuerystringLexer.SELECT:
                    return new SelectNode(inputType, token);
                case LinqToQuerystringLexer.INLINECOUNT:
                    return new InlineCountNode(inputType, token);
                case LinqToQuerystringLexer.NOT:
                    return new NotNode(inputType, token);
                case LinqToQuerystringLexer.AND:
                    return new AndNode(inputType, token);
                case LinqToQuerystringLexer.OR:
                    return new OrNode(inputType, token);
                case LinqToQuerystringLexer.EQUALS:
                    return new EqualsNode(inputType, token);
                case LinqToQuerystringLexer.NOTEQUALS:
                    return new NotEqualsNode(inputType, token);
                case LinqToQuerystringLexer.GREATERTHAN:
                    return new GreaterThanNode(inputType, token);
                case LinqToQuerystringLexer.GREATERTHANOREQUAL:
                    return new GreaterThanOrEqualNode(inputType, token);
                case LinqToQuerystringLexer.LESSTHAN:
                    return new LessThanNode(inputType, token);
                case LinqToQuerystringLexer.LESSTHANOREQUAL:
                    return new LessThanOrEqualNode(inputType, token);
                case LinqToQuerystringLexer.STARTSWITH:
                    return new StartsWithNode(inputType, token);
                case LinqToQuerystringLexer.ENDSWITH:
                    return new EndsWithNode(inputType, token);
                case LinqToQuerystringLexer.SUBSTRINGOF:
                    return new SubstringOfNode(inputType, token);
                case LinqToQuerystringLexer.DYNAMICIDENTIFIER:
                    return new DynamicIdentifierNode(inputType, token);
                case LinqToQuerystringLexer.IDENTIFIER:
                    return new IdentifierNode(inputType, token);
                case LinqToQuerystringLexer.STRING:
                    return new StringNode(inputType, token);
                case LinqToQuerystringLexer.BOOL:
                    return new BoolNode(inputType, token);
                case LinqToQuerystringLexer.INT:
                    return new IntNode(inputType, token);
                case LinqToQuerystringLexer.DATETIME:
                    return new DateTimeNode(inputType, token);
                case LinqToQuerystringLexer.DESC:
                    return new DescNode(inputType, token);
                case LinqToQuerystringLexer.ASC:
                    return new AscNode(inputType, token);
            }

            return null;
        }
    }
}