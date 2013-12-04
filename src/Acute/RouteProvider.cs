namespace Acute
{
    public abstract class RouteProvider
    {
        public RouteProvider When(string path, RouteConfig routeConfig)
        {
            return this;
        }
    }
}