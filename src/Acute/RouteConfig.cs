using System;

namespace Acute
{
    public class RouteConfig
    {
        public string TemplateUrl { get; set; }
        public Type Controller { get; set; }
    }

    public class RouteConfig<TController> : RouteConfig where TController : Controller
    {
    }

    
}