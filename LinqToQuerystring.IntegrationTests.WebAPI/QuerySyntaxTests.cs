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

    public class UrlEncoding : QuerySyntaxTests
    {
        private Because of = () => response = browser.Get(
            "/api/data?$filter=Name%20eq%20%27x%20y%20%26%20z%27",
            (with) =>
            {
                with.Header("Accept", "application/json");
                with.HttpRequest();
            });

        private It should_return_200_ok = () => response.StatusCode.ShouldEqual(HttpStatusCode.OK);
    }

    public class UrlEncodingForDollarSign : QuerySyntaxTests
    {
        private Because of = () => response = browser.Get(
            "/api/data?%24filter=Name%20eq%20%27x%20y%20%26%20z%27",
            (with) =>
            {
                with.Header("Accept", "application/json");
                with.HttpRequest();
            });

        private It should_return_200_ok = () => response.StatusCode.ShouldEqual(HttpStatusCode.OK);
    }

    public class NonGenericSelect : QuerySyntaxTests
    {
        private Because of = () => response = browser.Get(
            "/api/nongeneric?$select=Name,Age",
            (with) =>
            {
                with.Header("Accept", "application/json");
                with.HttpRequest();
            });

        private It should_return_200_ok = () => response.StatusCode.ShouldEqual(HttpStatusCode.OK);
    }

    public class NonGenericFilter : QuerySyntaxTests
    {
        private Because of = () => response = browser.Get(
            "/api/nongeneric?$filter=Age gt 28",
            (with) =>
            {
                with.Header("Accept", "application/json");
                with.HttpRequest();
            });

        private It should_return_200_ok = () => response.StatusCode.ShouldEqual(HttpStatusCode.OK);

        private It should_return_Pete = () => response.Content.ReadAsStringAsync().Result.ShouldContain("Pete");

        private It should_not_return_Kathryn = () => response.Content.ReadAsStringAsync().Result.ShouldNotContain("Kathryn");
    }
}
