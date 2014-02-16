using System.Runtime.CompilerServices;

namespace Acute.Angular
{
    //[Imported]
    [AngularService("$routeProvider")]
    internal sealed class RouteProvider
    {
         
      [InlineCode("{this}.otherwise({route})")]
      public RouteProvider otherwise(RouteConfig route)
      {
         return this;
      }

      [InlineCode("{this}.when({path},{route})")]
      public RouteProvider when(string path, RouteConfig route)
      {
         return this;
      }
    }
}