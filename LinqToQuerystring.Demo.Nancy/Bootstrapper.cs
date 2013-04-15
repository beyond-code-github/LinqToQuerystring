namespace LinqToQuerystring.Demo.Nancy
{
    using global::Nancy;
    using global::Nancy.Bootstrapper;
    using global::Nancy.Diagnostics;
    using global::Nancy.TinyIoc;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get { return new DiagnosticsConfiguration { Password = @"password" }; }
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            StaticConfiguration.EnableRequestTracing = true;
        }
    }
}