using System.Net.Http;
using System.Runtime.CompilerServices;
using Acute.Http;

namespace Test.Scenarios.Http
{
    public class HttpTestController : Acute.Controller
    {
        private readonly IHttp _http;
         
        [Reflectable]
        public HttpTestController(IHttp http)
        {
            _http = http;
        }

        public HttpStatusCode Status { get; private set; }
        public string Data { get; private set; }

        public int DataObjectId { get; set; } 

        public void GetStringData()
        {
             _http.GetAsync("/foo/bar")
                        .ContinueWith(task =>
                            {
                                Status = task.Result.Status;
                                Data = task.Result.Data;
                            });
        }

        public void GetObjectData()
        {
             _http.GetAsync("/foo/bar")
                        .ContinueWith(task =>
                            {
                                Status = task.Result.Status;
                                var dataObject = task.Result.DataAs<FooBar>();
                                DataObjectId = dataObject.Id;
                            });
        }
    }
}