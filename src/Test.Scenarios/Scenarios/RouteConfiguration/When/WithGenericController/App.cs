using Acute;

namespace Test.Scenarios.RouteConfiguration.When.WithGenericController
{
    public class App : Acute.App
    {
        public App()
        {
        }

        protected override void ConfigureRoutes(RouteProvider routeProvider)
        {
            //route-config with default constuctor and no initializers
            routeProvider.When("/path/for/route/config/with/no/initializers", new RouteConfig<DefaultController>() );

            //route-config with initalizer
            routeProvider.When("/path/for/route/config/with/initializer", new RouteConfig<DefaultController>{TemplateUrl = "/a/template.html"} );
        }
    }
}