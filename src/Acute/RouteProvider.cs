﻿using System;

namespace Acute
{
    public class RouteProvider
    {
        private readonly Angular.RouteProvider _angularRouteProvider;

        internal RouteProvider(Angular.RouteProvider _routeProvider)
        {
            _angularRouteProvider = _routeProvider;
        }

        public RouteProvider When(string path, RouteConfig routeConfig)
        {
            _angularRouteProvider.when(path, routeConfig.ToAngularRouteConfig());
            return this;
        }

        public RouteProvider Otherwise(RouteConfig routeConfig)
        {
            _angularRouteProvider.otherwise(routeConfig.ToAngularRouteConfig());
            return this;
        }
    }
}