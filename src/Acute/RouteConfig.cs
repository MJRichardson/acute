namespace Acute
{
    public class RouteConfig
    {
        public string TemplateUrl { get; set; } 
    }

    public class RouteConfig<TController> : RouteConfig where TController : Controller
    {
    }

    
}