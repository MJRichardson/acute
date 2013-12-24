namespace Acute.Compiler.JavascriptTemplates.Invocations.RouteProvider
{
    internal partial class WhenTemplate
    {
        public string Path { get; private set; }
        public string RouteConfig { get; private set; }

        public WhenTemplate(string path, string routeConfig)
        {
            Path = path;
            RouteConfig = routeConfig;
        }
    }
}