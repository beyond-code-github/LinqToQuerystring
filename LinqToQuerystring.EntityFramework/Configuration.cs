namespace LinqToQuerystring.EntityFramework
{
    using LinqToQuerystring.Utils;

    public static class Configuration
    {
        public static void Init()
        {
            if (!LinqToQuerystring.Configuration.CustomNodes.ContainsKey("DbQueryProvider"))
            {
                LinqToQuerystring.Configuration.CustomNodes.Add("DbQueryProvider", new CustomNodeMappings());
            }

            var objectQueryNodes = LinqToQuerystring.Configuration.CustomNodes["DbQueryProvider"];
            if (!objectQueryNodes.ContainsKey(LinqToQuerystringLexer.EXPAND))
            {
                objectQueryNodes.Add(
                    LinqToQuerystringLexer.EXPAND, (type, token, factory) => new ExpandNode(type, token, factory));
            }
        }
    }
}
