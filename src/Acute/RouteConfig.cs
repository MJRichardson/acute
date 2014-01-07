using System;

namespace Acute
{
    [ScriptObjectLiteral]
    public class RouteConfig
    {
        [ScriptName("templateUrl")]
        public string TemplateUrl { get; set; }

        [ScriptExternal]
        public Type Controller { get; set; }

        protected string controller { get; set; }

    }

    [CustomScriptType]
    public class RouteConfig<TController> : RouteConfig where TController : Controller
    {
        public RouteConfig()
        {

        }
    }

    
}