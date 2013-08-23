namespace LinqToQuerystring.IntegrationTests.WebApi
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Tracing;

    using Machine.Specifications;

    using WebAPI.Testing;

    public abstract class QuerySyntaxTests
    {
        protected static Browser browser;

        protected static HttpResponseMessage response;

        protected Establish context = () =>
        {
            var config = new HttpConfiguration();
            config.Services.Replace(typeof(ITraceWriter), new SimpleTracer());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            browser = new Browser(config);
        };
    }

    public class InlineCount : QuerySyntaxTests
    {
        private Because of = () => response = browser.Get(
            "/api/data?$inlinecount=allpages",
            (with) =>
            {
                with.Header("Accept", "application/json");
                with.HttpRequest();
            });

        private It should_return_200_ok = () => response.StatusCode.ShouldEqual(HttpStatusCode.OK);
    }

    public class Select : QuerySyntaxTests
    {
        private Because of = () => response = browser.Get(
            "/api/data?$select=Name,Age",
            (with) =>
            {
                with.Header("Accept", "application/json");
                with.HttpRequest();
            });

        private It should_return_200_ok = () => response.StatusCode.ShouldEqual(HttpStatusCode.OK);
    }
}
