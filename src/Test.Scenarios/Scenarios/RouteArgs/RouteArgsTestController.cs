using Acute;
using Acute.Services;

namespace Test.Scenarios.RouteArgs
{
    public class RouteArgsTestController : Acute.Controller
    {
        public RouteArgsTestController(IRouteArgs routeArgs, Scope scope)
        {
            scope.Model.ArgsBag = new {Id = routeArgs.Bag.Id, Name = routeArgs.Bag.Name };

            var typedArgs = routeArgs.As<TypedRouteArgs>();
            scope.Model.TypedArgs = new
                {
                    Id = typedArgs.Id,
                    Name = typedArgs.Name
                };
        } 
    }
}