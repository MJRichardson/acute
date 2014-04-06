using System;
using Acute.Services;

namespace Test.Scenarios.Http
{
    public class HttpTestController : Acute.Controller
    {
        private readonly IHttp _http;
         
        public HttpTestController(IHttp http)
        {
            _http = http;
        }


        public override void Control(dynamic scope)
        {
            scope.getStringData = (Action)(() => _http.GetAsync("/foo/bar")
                                                      .ContinueWith(task =>
                                                          {
                                                              scope.status = task.Result.Status;
                                                              scope.data = task.Result.Data;
                                                          }));

            scope.getObjectData = (Action) (() =>  
             _http.GetAsync("/foo/bar")
                        .ContinueWith(task =>
                            {
                                scope.status = task.Result.Status;
                                var dataObject = task.Result.DataAs<FooBar>();
                                scope.dataObjectId = dataObject.Id;
                            }));
        }
    }
}