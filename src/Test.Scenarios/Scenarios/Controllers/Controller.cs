using System.Runtime.CompilerServices;
using Acute.Http;

namespace Test.Scenarios.Controllers
{
    public class Controller : Acute.Controller
    {
        private string _simpleString;

        [Reflectable]
        public Controller(IHttp http)
        {
            _simpleString = "Yabba dabba doo!";

            var result = http.GetAsync("http://foo.com/bar").Result;
        }

        public string SimpleString()
        {
            return _simpleString;
        }

    }
}