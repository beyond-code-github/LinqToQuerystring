namespace LinqToQuerystring
{
    using System;

    public static class Configuration
    {
        public static Func<Type, Type> DefaultTypeMap = (type) => type;

        public static Func<Type, Type, Type> DefaultTypeConversionMap = (from, to) => to;

        /// <summary>
        /// Exstensibility point for specifying an alternate type mapping when casting to IEnumerable
        /// </summary>
        public static Func<Type, Type> EnumerableTypeMap { get; set; }

        /// <summary>
        /// Exstensibility point for specifying an alternate type mapping when casting values
        /// </summary>
        public static Func<Type, Type, Type> TypeConversionMap { get; set; }

        static Configuration()
        {
            EnumerableTypeMap = DefaultTypeMap;
            TypeConversionMap = DefaultTypeConversionMap;
        }
    }
}
