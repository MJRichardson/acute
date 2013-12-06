using Acute;

namespace Test.Scenarios.Scenarios.RouteConfiguration
{
    public class App : Acute.App
    {
        public App(RouteProvider routeProvider)
        {
            routeProvider.When("", new RouteConfig<DefaultController> {TemplateUrl = "blah.html"});
        } 
    }
}