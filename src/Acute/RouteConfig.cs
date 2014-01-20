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
           return new Angular.RouteConfig
               {
                   TemplateUrl = TemplateUrl
               }; 
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