using System;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace Test.Scenarios.Controllers
{
    public class Controller : Acute.Controller
    {
        private string _simpleString;

        public Controller()
        {
            _simpleString = "Yabba dabba doo!";

        }

        public string SimpleString()
        {
            return _simpleString;
        }

        public override void Control(dynamic scope)
        {
            var simpleStringFunc = new Func<string>(() => _simpleString);
            scope.SimpleString = () => _simpleString;
        }
    }
}