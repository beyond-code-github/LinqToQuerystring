namespace LinqToQuerystring.WebApi
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Filters;

    using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

    public class LinqToQueryableAttribute : ActionFilterAttribute
    {
        private readonly bool forceDynamicProperties;

        private readonly int maxPageSize;

        public LinqToQueryableAttribute(bool forceDynamicProperties = false, int maxPageSize = -1)
        {
            this.forceDynamicProperties = forceDynamicProperties;
            this.maxPageSize = maxPageSize;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            object responseObject;
            actionExecutedContext.Response.TryGetContentValue(out responseObject);
            var originalquery = responseObject as IQueryable;

            if (originalquery != null)
            {
                var queryString = actionExecutedContext.Request.RequestUri.Query;

                var genericType = originalquery.GetType().GetGenericArguments()[0];
                var query = HttpUtility.UrlDecode(queryString);

                var reply = originalquery.LinqToQuerystring(genericType, query, this.forceDynamicProperties, this.maxPageSize);

                var queryableType = typeof(IQueryable<>).GetGenericTypeDefinition();
                var genericArgs = reply.GetType().GetGenericArguments();
                var replyType = queryableType.MakeGenericType(genericArgs);

                var configuraton = actionExecutedContext.ActionContext.ControllerContext.Configuration;
                var conneg = (IContentNegotiator)configuraton.Services.GetService(typeof(IContentNegotiator));
                var formatter = conneg.Negotiate(
                    replyType,
                    actionExecutedContext.Request,
                    configuraton.Formatters);

                actionExecutedContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent(replyType, reply, formatter.Formatter)
                };
            }
        }
    }
}
