using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Test.Blah
{
    class Program
    {
        static void Main()
        {
            var app = new App();
            var allTypes = Assembly.GetExecutingAssembly().GetTypes();
        }
    }
}
