using System.Runtime.CompilerServices;

namespace Acute.Angular
{
    [AngularService("$cookies")]
    internal class Cookies
    {
      [InlineCode("{this}[{key}]")]
      public string Get(string key)
      {
          return null;
      } 

      [InlineCode("{this}[{key}] = value")]
        public string Set(string key, string value)
        {
            return null;
        }
    }
}