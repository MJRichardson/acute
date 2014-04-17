using System;
using System.Runtime.CompilerServices;

namespace Acute
{
    public class RouteConfig
    {
        public string TemplateUrl { get; set; }
        public Type Controller { get; set; }

        internal Angular.RouteConfig ToAngularRouteConfig()
        {
            var angularRouteConfig = new Angular.RouteConfig();

            if (!string.IsNullOrEmpty(TemplateUrl))
                angularRouteConfig.TemplateUrl = TemplateUrl;

            if (Controller != null)
                angularRouteConfig.Controller = Controller.AsAngularServiceName() ;

            return angularRouteConfig;
        }

    }

    public class RouteConfig<TController> : RouteConfig where TController : Controller
    {
        public RouteConfig()
        {
            Controller = typeof (TController);
        }
    }


}