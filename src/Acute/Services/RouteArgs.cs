using Acute.Angular;

namespace Acute.Services
{
    public interface IRouteArgs
    {
        dynamic Bag { get; }

        T As<T>() where T : class;
    }

    public class RouteArgs : IRouteArgs
    {
        private readonly RouteParams _routeParams;

        internal RouteArgs(Angular.RouteParams routeParams)
        {
            _routeParams = routeParams;
            Bag = _routeParams;
        }

        public dynamic Bag { get; private set; }

        public T As<T>() where T : class
        {
            return  _routeParams as T;
        }
    }
}