namespace LinqToQuerystring
{
    using System;
    using System.Collections.Generic;

    using LinqToQuerystring.Utils;

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

        /// <summary>
        /// Allows the specification of custom tree nodes for particular situations, i.e Entity Framework include
        /// </summary>
        public static Dictionary<string, CustomNodeMappings> CustomNodes { get; set; }

        public static void Reset()
        {
            EnumerableTypeMap = DefaultTypeMap;
            TypeConversionMap = DefaultTypeConversionMap;
            CustomNodes = new Dictionary<string, CustomNodeMappings>();
        }

        static Configuration()
        {
            Reset();
        }
    }
}
