using System;
using Acute;

namespace Test.Scenarios.Scenarios.RouteConfiguration
{
    public class App : Acute.App
    {
        public App(RouteProvider routeProvider)
        {
            //routeProvider.When("", new RouteConfig<DefaultController> {TemplateUrl = "blah.html"});
            routeProvider.When("", new RouteConfig {TemplateUrl = "blah.html"});

            //var name = NameFromType<App>();

        } 

        //private string NameFromType<T>()
        //{
        //    return typeof (T).FullName;
        //}
    }
}