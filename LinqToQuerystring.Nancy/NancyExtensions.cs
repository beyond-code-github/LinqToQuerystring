namespace LinqToQuerystring.Nancy
{
    using System.Collections.Generic;
    using System.Linq;

    public static class NancyExtensions
    {
        public static dynamic LinqToQuerystring<T>(this IQueryable<T> query, IDictionary<string, object> queryDictionary, bool forceDynamicProperties = false, int maxPageSize = -1)
        {
            var genericType = query.GetType().GetGenericArguments()[0];

            var joined = string.Join(
                "&", queryDictionary.Select(o => o.Key + "=" + o.Value));
            var queryString = !string.IsNullOrEmpty(joined) ? "?" + joined : string.Empty;

            return query.LinqToQuerystring(genericType, queryString, forceDynamicProperties, maxPageSize);
        }
    }
}
