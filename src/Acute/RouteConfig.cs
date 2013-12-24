using System;

namespace Acute
{
    [ScriptObjectLiteral]
    public class RouteConfig
    {
        [ScriptName("templateUrl")]
        public string TemplateUrl { get; set; }
        public Type Controller { get; set; }
    }

    public class RouteConfig<TController> : RouteConfig where TController : Controller
    {
    }

    
}