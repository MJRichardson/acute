using System;

namespace Acute.Angular
{
    /// <summary>
    /// http://docs.angularjs.org/api/AUTO.$provide
    /// </summary>
    internal class Provide
    {
        public Provide service(string name, Func<object> constructor )
        {
            return this;
        }
    }
}