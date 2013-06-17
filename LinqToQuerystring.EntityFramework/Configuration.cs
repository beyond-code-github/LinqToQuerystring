namespace LinqToQuerystring.EntityFramework
{
    using System.Data.Objects;

    using LinqToQuerystring.Utils;

    public static class Configuration
    {
        public static void Init()
        {
            if (!LinqToQuerystring.Configuration.CustomNodes.ContainsKey(typeof(ObjectQuery)))
            {
                LinqToQuerystring.Configuration.CustomNodes.Add(typeof(ObjectQuery), new CustomNodeMappings());
            }

            var objectQueryNodes = LinqToQuerystring.Configuration.CustomNodes[typeof(ObjectQuery)];
            if (!objectQueryNodes.ContainsKey(LinqToQuerystringLexer.EXPAND))
            {
                objectQueryNodes.Add(
                    LinqToQuerystringLexer.EXPAND, (type, token, factory) => new ExpandNode(type, token, factory));
            }
        }
    }
}
