using System.Net.Http;
using System.Runtime.CompilerServices;

namespace Test.Scenarios.Controllers
{
    public class Controller : Acute.Controller
    {
        private string _simpleString;

        [Reflectable]
        public Controller()
        {
            _simpleString = "Yabba dabba doo!";

        }

        public string SimpleString()
        {
            return _simpleString;
        }

    }
}