namespace LinqToQuerystring
{
    using System;

    public static class Configuration
    {
        public static Func<Type, Type> DefaultMapTypeForEnumerable = (type) => type;

        public static Func<Type, Type> MapTypeForEnumerable { get; set; }

        static Configuration()
        {
            MapTypeForEnumerable = DefaultMapTypeForEnumerable;
        }
    }
}
