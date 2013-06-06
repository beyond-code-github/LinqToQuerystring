namespace LinqToQuerystring.WebApi
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Filters;

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

                dynamic reply = originalquery.LinqToQuerystring(genericType, query, this.forceDynamicProperties, this.maxPageSize);

                var mediaFormatter =
                    GlobalConfiguration.Configuration.Formatters.FirstOrDefault(o => o.CanWriteType(reply.GetType()));

                if (mediaFormatter == null)
                {
                    throw new InvalidOperationException(string.Format("No media type formatter was found for the type: {0}", reply.GetType().Name));
                }

                var response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new ObjectContent(reply.GetType(), reply, mediaFormatter); ;

                actionExecutedContext.Response = response;
            }
        }
    }
}
