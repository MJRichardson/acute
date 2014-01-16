using System.Runtime.CompilerServices;

namespace Acute.Angular
{
    [Imported]
    internal sealed class RouteProvider
    {
         
      [InlineCode("{this}.otherwise({route})")]
      public RouteProvider otherwise(RouteMap route)
      {
         return this;
      }

      [InlineCode("{this}.when({path},{route})")]
      public RouteProvider when(string path, RouteMap route)
      {
         return this;
      }
    }
}