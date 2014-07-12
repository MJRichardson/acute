using System;
using Acute;
using Acute.Services;

namespace Test.Scenarios.Http
{
    public class HttpTestController : Acute.Controller
    {
         
        public HttpTestController(IHttp http, Scope scope)
        {
            scope.Model.getStringData = (Action)(() => http.GetAsync("/foo/bar")
                                                      .ContinueWith(task =>
                                                          {
                                                              scope.Model.status = task.Result.Status;
                                                              scope.Model.data = task.Result.Data;
                                                          }));

            scope.Model.getObjectData = (Action) (() =>  
             http.GetAsync("/foo/bar")
                        .ContinueWith(task =>
                            {
                                scope.Model.status = task.Result.Status;
                                var dataObject = task.Result.DataAs<FooBar>();
                                scope.Model.dataObjectId = dataObject.Id;
                            }));
        }


    }
}