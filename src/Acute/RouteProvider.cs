using System;

namespace Acute
{
    public abstract class RouteProvider
    {

        [AngularInject("$routeProvider")]
        private Angular.RouteProvider _angularRouteProvider;

        public RouteProvider When(string path, RouteConfig routeConfig)
        {
            _angularRouteProvider.when(path, new {templateUrl = routeConfig.TemplateUrl});
            return this;
        }
    }
}