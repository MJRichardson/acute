using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Acute;

namespace Test.Scenarios.Controllers
{
    public class Controller : Acute.Controller
    {
        private string _simpleString;

        public Controller(Scope scope)
        {
            _simpleString = "Yabba dabba doo!";

            var simpleStringFunc = new Func<string>(() => _simpleString);
            scope.Model.SimpleString = simpleStringFunc;

            scope.Model.FromObjectInitializer = new List<string> {"Eenie", "Meenie"};

            scope.Model.FromClass = new ViewModel {GreenBottleCount = 99};

        }

        public string SimpleString()
        {
            return _simpleString;
        }

    }
}