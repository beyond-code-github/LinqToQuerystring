namespace LinqToQuerystring.TreeNodes
{
    using System;

    using Antlr.Runtime.Tree;

    using LinqToQuerystring.TreeNodes.Aggregates;
    using LinqToQuerystring.TreeNodes.Comparisons;
    using LinqToQuerystring.TreeNodes.DataTypes;
    using LinqToQuerystring.TreeNodes.Functions;

    public class TreeNodeFactory : CommonTreeAdaptor
    {
        private readonly Type inputType;

        private readonly bool forceDynamicProperties;

        public TreeNodeFactory(Type inputType, bool forceDynamicProperties)
        {
            this.inputType = inputType;
            this.forceDynamicProperties = forceDynamicProperties;
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
                    return new TopNode(inputType, token, this);
                case LinqToQuerystringLexer.SKIP:
                    return new SkipNode(inputType, token, this);
                case LinqToQuerystringLexer.ORDERBY:
                    return new OrderByNode(inputType, token, this);
                case LinqToQuerystringLexer.FILTER:
                    return new FilterNode(inputType, token, this);
                case LinqToQuerystringLexer.SELECT:
                    return new SelectNode(inputType, token, this);
                case LinqToQuerystringLexer.INLINECOUNT:
                    return new InlineCountNode(inputType, token, this);
                case LinqToQuerystringLexer.EXPAND:
                    return new ExpandNode(inputType, token, this);
                case LinqToQuerystringLexer.NOT:
                    return new NotNode(inputType, token, this);
                case LinqToQuerystringLexer.AND:
                    return new AndNode(inputType, token, this);
                case LinqToQuerystringLexer.OR:
                    return new OrNode(inputType, token, this);
                case LinqToQuerystringLexer.EQUALS:
                    return new EqualsNode(inputType, token, this);
                case LinqToQuerystringLexer.NOTEQUALS:
                    return new NotEqualsNode(inputType, token, this);
                case LinqToQuerystringLexer.GREATERTHAN:
                    return new GreaterThanNode(inputType, token, this);
                case LinqToQuerystringLexer.GREATERTHANOREQUAL:
                    return new GreaterThanOrEqualNode(inputType, token, this);
                case LinqToQuerystringLexer.LESSTHAN:
                    return new LessThanNode(inputType, token, this);
                case LinqToQuerystringLexer.LESSTHANOREQUAL:
                    return new LessThanOrEqualNode(inputType, token, this);
                case LinqToQuerystringLexer.STARTSWITH:
                    return new StartsWithNode(inputType, token, this);
                case LinqToQuerystringLexer.ENDSWITH:
                    return new EndsWithNode(inputType, token, this);
                case LinqToQuerystringLexer.SUBSTRINGOF:
                    return new SubstringOfNode(inputType, token, this);
                case LinqToQuerystringLexer.TOLOWER:
                    return new ToLowerNode(inputType, token, this);
                case LinqToQuerystringLexer.TOUPPER:
                    return new ToUpperNode(inputType, token, this);
                case LinqToQuerystringLexer.YEAR:
                    return new YearNode(inputType, token, this);
                case LinqToQuerystringLexer.YEARS:
                    return new YearsNode(inputType, token, this);
                case LinqToQuerystringLexer.MONTH:
                    return new MonthNode(inputType, token, this);
                case LinqToQuerystringLexer.DAY:
                    return new DayNode(inputType, token, this);
                case LinqToQuerystringLexer.DAYS:
                    return new DaysNode(inputType, token, this);
                case LinqToQuerystringLexer.HOUR:
                    return new HourNode(inputType, token, this);
                case LinqToQuerystringLexer.HOURS:
                    return new HoursNode(inputType, token, this);
                case LinqToQuerystringLexer.MINUTE:
                    return new MinuteNode(inputType, token, this);
                case LinqToQuerystringLexer.MINUTES:
                    return new MinutesNode(inputType, token, this);
                case LinqToQuerystringLexer.SECOND:
                    return new SecondNode(inputType, token, this);
                case LinqToQuerystringLexer.SECONDS:
                    return new SecondsNode(inputType, token, this);
                case LinqToQuerystringLexer.ANY:
                    return new AnyNode(inputType, token, this);
                case LinqToQuerystringLexer.ALL:
                    return new AllNode(inputType, token, this);
                case LinqToQuerystringLexer.COUNT:
                    return new CountNode(inputType, token, this);
                case LinqToQuerystringLexer.AVERAGE:
                    return new AverageNode(inputType, token, this);
                case LinqToQuerystringLexer.MAX:
                    return new MaxNode(inputType, token, this);
                case LinqToQuerystringLexer.MIN:
                    return new MinNode(inputType, token, this);
                case LinqToQuerystringLexer.SUM:
                    return new SumNode(inputType, token, this);
                case LinqToQuerystringLexer.ALIAS:
                    return new AliasNode(inputType, token, this);
                case LinqToQuerystringLexer.DYNAMICIDENTIFIER:
                    return new DynamicIdentifierNode(inputType, token, this);
                case LinqToQuerystringLexer.IDENTIFIER:
                    if (forceDynamicProperties)
                    {
                        return new DynamicIdentifierNode(inputType, token, this);
                    }
                    return new IdentifierNode(inputType, token, this);
                case LinqToQuerystringLexer.STRING:
                    return new StringNode(inputType, token, this);
                case LinqToQuerystringLexer.BOOL:
                    return new BoolNode(inputType, token, this);
                case LinqToQuerystringLexer.INT:
                    return new IntNode(inputType, token, this);
                case LinqToQuerystringLexer.DATETIME:
                    return new DateTimeNode(inputType, token, this);
                case LinqToQuerystringLexer.DOUBLE:
                    return new DoubleNode(inputType, token, this);
                case LinqToQuerystringLexer.SINGLE:
                    return new SingleNode(inputType, token, this);
                case LinqToQuerystringLexer.DECIMAL:
                    return new DecimalNode(inputType, token, this);
                case LinqToQuerystringLexer.LONG:
                    return new LongNode(inputType, token, this);
                case LinqToQuerystringLexer.BYTE:
                    return new ByteNode(inputType, token, this);
                case LinqToQuerystringLexer.GUID:
                    return new GuidNode(inputType, token, this);
                case LinqToQuerystringLexer.DESC:
                    return new DescNode(inputType, token, this);
                case LinqToQuerystringLexer.ASC:
                    return new AscNode(inputType, token, this);
                case LinqToQuerystringLexer.NULL:
                    return new NullNode(inputType, token, this);
                case LinqToQuerystringLexer.IGNORED:
                    return new IgnoredNode(inputType, token, this);
            }

            return null;
        }
    }
}