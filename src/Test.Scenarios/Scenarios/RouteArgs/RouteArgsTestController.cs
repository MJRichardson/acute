using Acute;
using Acute.Services;

namespace Test.Scenarios.RouteArgs
{
    public class RouteArgsTestController : Acute.Controller
    {
        public RouteArgsTestController(IRouteArgs routeArgs, Scope scope)
        {
           var typedArgs = routeArgs.As<TypedRouteArgs>();
            scope.Model.Id = typedArgs.Id;
            scope.Model.Name = typedArgs.Name;
        } 
    }
}