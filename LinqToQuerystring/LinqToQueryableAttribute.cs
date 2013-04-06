namespace LinqToQuerystring
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http.Filters;

    public class LinqToQueryableAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            object responseObject;
            actionExecutedContext.Response.TryGetContentValue(out responseObject);
            var originalquery = responseObject as IQueryable;

            if (originalquery != null)
            {
                var queryString = actionExecutedContext.Request.RequestUri.Query;
                if (!string.IsNullOrEmpty(queryString))
                {
                    var genericType = originalquery.GetType().GetGenericArguments()[0];
                    var query = HttpUtility.UrlDecode(queryString);

                    actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.OK, originalquery.LinqToQuerystring(query, genericType));
                }
            }
        }
    }
}
