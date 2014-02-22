using System.Net.Http;
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

            http.GetAsync("http://foo.com/bar")
                .ContinueWith(task => Status = task.Result.Status);
        }

        public string SimpleString()
        {
            return _simpleString;
        }

        public HttpStatusCode Status { get; set; }

    }
}