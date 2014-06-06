using System.Runtime.CompilerServices;
using Acute.Angular;

namespace Acute.Services
{
    public class RouteArgs
    {
        [Reflectable]
        internal RouteArgs(RouteParams routeParams)
        {
            Args = routeParams;
        }

        public dynamic Args { get; set; }
    }

}