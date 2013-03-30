namespace LinqToQuerystring.TreeNodes
{
    using Antlr.Runtime.Tree;

    public class TreeNodeFactory : CommonTreeAdaptor
    {
        public override object Create(Antlr.Runtime.IToken token)
        {
            if (token == null)
            {
                return new CommonTree();
            }

            switch (token.Type)
            {
                case LinqToQuerystringLexer.TOP:
                    return new TopNode(token);
                case LinqToQuerystringLexer.SKIP:
                    return new SkipNode(token);
                case LinqToQuerystringLexer.ORDERBY:
                    return new OrderByNode(token);
                case LinqToQuerystringLexer.FILTER:
                    return new FilterNode(token);
                case LinqToQuerystringLexer.NOT:
                    return new NotNode(token);
                case LinqToQuerystringLexer.AND:
                    return new AndNode(token);
                case LinqToQuerystringLexer.OR:
                    return new OrNode(token);
                case LinqToQuerystringLexer.EQUALS:
                    return new EqualsNode(token);
                case LinqToQuerystringLexer.NOTEQUALS:
                    return new NotEqualsNode(token);
                case LinqToQuerystringLexer.GREATERTHAN:
                    return new GreaterThanNode(token);
                case LinqToQuerystringLexer.GREATERTHANOREQUAL:
                    return new GreaterThanOrEqualNode(token);
                case LinqToQuerystringLexer.LESSTHAN:
                    return new LessThanNode(token);
                case LinqToQuerystringLexer.LESSTHANOREQUAL:
                    return new LessThanOrEqualNode(token);
                case LinqToQuerystringLexer.IDENTIFIER:
                    return new IdentifierNode(token);
                case LinqToQuerystringLexer.STRING:
                    return new StringNode(token);
                case LinqToQuerystringLexer.BOOL:
                    return new BoolNode(token);
                case LinqToQuerystringLexer.INT:
                    return new IntNode(token);
                case LinqToQuerystringLexer.DATETIME:
                    return new DateTimeNode(token);
                case LinqToQuerystringLexer.DESC:
                    return new DescNode(token);
                case LinqToQuerystringLexer.ASC:
                    return new AscNode(token);
            }

            return null;
        }
    }
}