using Acute;

namespace Test.Scenarios.RouteConfiguration.When.WithGenericController
{
    public class App : Acute.App
    {
        public App(RouteProvider routeProvider)
        {
            var routeConfig = new RouteConfig<DefaultController>();
            routeProvider.When("/this/is/a/path", routeConfig );
        } 
    }
}