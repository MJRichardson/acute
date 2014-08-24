using System.Runtime.CompilerServices;
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
        [ScriptName("_routeParams")]
        private readonly RouteParams _routeParams;

        [Reflectable]
        internal RouteArgs(Angular.RouteParams routeParams)
        {
            _routeParams = routeParams;
            Bag = _routeParams;
        }

        public dynamic Bag { get; private set; }

        public T As<T>() where T : class
        {
            return AsInternal<T>();
        }

        [InlineCode("{this}._routeParams")]
        private T AsInternal<T>() where T : class
        {
            return default(T);
        }
    }
}