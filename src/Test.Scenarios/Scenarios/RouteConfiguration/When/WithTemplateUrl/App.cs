using Acute;

namespace Test.Scenarios.RouteConfiguration.When.WithTemplateUrl
{
    public class App : Acute.App
    {
        public App()
        {
        }

        protected override void ConfigureRoutes(RouteProvider routeProvider)
        {
            routeProvider.When("/this/is/a/path", new RouteConfig {TemplateUrl = "/this/is/a/template.html"});
        }
    }
}