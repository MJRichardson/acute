using System.Runtime.CompilerServices;

namespace Acute.Angular
{
    [AngularService("$cookieStore")]
    internal class CookieStore
    {
      [InlineCode("{this}.get({key})")] 
        public object Get(string key)
        {
            return null;
        } 

      [InlineCode("{this}.put({key}, {value})")] 
        public void Put(string key, object value)
        {
        }

      [InlineCode("{this}.remove({key})")] 
        public void Remove(string key)
        {}
    }
}