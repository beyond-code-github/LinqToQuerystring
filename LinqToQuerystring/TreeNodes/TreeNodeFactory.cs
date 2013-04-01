namespace LinqToQuerystring.TreeNodes
{
    using Antlr.Runtime.Tree;

    public class TreeNodeFactory<T> : CommonTreeAdaptor
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
                    return new TopNode<T>(token);
                case LinqToQuerystringLexer.SKIP:
                    return new SkipNode<T>(token);
                case LinqToQuerystringLexer.ORDERBY:
                    return new OrderByNode<T>(token);
                case LinqToQuerystringLexer.FILTER:
                    return new FilterNode<T>(token);
                case LinqToQuerystringLexer.SELECT:
                    return new SelectNode<T>(token);
                case LinqToQuerystringLexer.NOT:
                    return new NotNode<T>(token);
                case LinqToQuerystringLexer.AND:
                    return new AndNode<T>(token);
                case LinqToQuerystringLexer.OR:
                    return new OrNode<T>(token);
                case LinqToQuerystringLexer.EQUALS:
                    return new EqualsNode<T>(token);
                case LinqToQuerystringLexer.NOTEQUALS:
                    return new NotEqualsNode<T>(token);
                case LinqToQuerystringLexer.GREATERTHAN:
                    return new GreaterThanNode<T>(token);
                case LinqToQuerystringLexer.GREATERTHANOREQUAL:
                    return new GreaterThanOrEqualNode<T>(token);
                case LinqToQuerystringLexer.LESSTHAN:
                    return new LessThanNode<T>(token);
                case LinqToQuerystringLexer.LESSTHANOREQUAL:
                    return new LessThanOrEqualNode<T>(token);
                case LinqToQuerystringLexer.IDENTIFIER:
                    return new IdentifierNode<T>(token);
                case LinqToQuerystringLexer.STRING:
                    return new StringNode<T>(token);
                case LinqToQuerystringLexer.BOOL:
                    return new BoolNode<T>(token);
                case LinqToQuerystringLexer.INT:
                    return new IntNode<T>(token);
                case LinqToQuerystringLexer.DATETIME:
                    return new DateTimeNode<T>(token);
                case LinqToQuerystringLexer.DESC:
                    return new DescNode<T>(token);
                case LinqToQuerystringLexer.ASC:
                    return new AscNode<T>(token);
            }

            return null;
        }
    }
}