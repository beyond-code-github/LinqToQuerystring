namespace LinqToQuerystring.IntegrationTests.WebApi
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Tracing;

    using Machine.Specifications;

    using WebAPI.Testing;

    public abstract class ContentNegotiationTestsBase
    {
        protected static Browser browser;

        protected static HttpResponseMessage response;

        protected Establish context = () =>
        {
            var config = new HttpConfiguration();
            config.Services.Replace(typeof(ITraceWriter), new SimpleTracer());
            config.Formatters.Add(new CsvMediaTypeFormatter());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            browser = new Browser(config);
        };
    }

    public class AcceptsJson : ContentNegotiationTestsBase
    {
        private Because of = () => response = browser.Get(
            "/api/data/",
            (with) =>
            {
                with.Header("Accept", "application/json");
                with.HttpRequest();
            });

        private It should_return_200_ok = () => response.StatusCode.ShouldEqual(HttpStatusCode.OK);
    }

    public class AcceptsXml : ContentNegotiationTestsBase
    {
        private Because of = () => response = browser.Get(
            "/api/data/",
            (with) =>
            {
                with.Header("Accept", "application/xml");
                with.HttpRequest();
            });

        private It should_return_200_ok = () => response.StatusCode.ShouldEqual(HttpStatusCode.OK);

        private It should_return_xml = () => response.Content.Headers.GetValues("Content-Type").FirstOrDefault().ShouldStartWith("application/xml");
    }

    public class Can_handle_media_type_mappings : ContentNegotiationTestsBase
    {
        private Because of = () => response = browser.Get(
            "/api/data?format=csv",
            (with) =>
            {
                with.Header("Accept", "text/csv");
                with.HttpRequest();
            });

        private It should_return_200_ok = () => response.StatusCode.ShouldEqual(HttpStatusCode.OK);

        private It should_return_xml = () => response.Content.Headers.GetValues("Content-Type").FirstOrDefault().ShouldStartWith("text/csv");
    }
}
