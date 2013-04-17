namespace LinqToQuerystring.Demo.Filters
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;

    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var argumentException = actionExecutedContext.Exception as Exception;
            if (argumentException != null)
            {
                var message = string.IsNullOrEmpty(argumentException.Message)
                                  ? "An exception occurred"
                                  : argumentException.Message;

                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, message);
                actionExecutedContext.Response.Content.Headers.ContentType =
                    actionExecutedContext.Request.Content.Headers.ContentType;
            }
        }
    }
}