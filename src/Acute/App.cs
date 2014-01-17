using System;
using Acute.Angular;

namespace Acute
{
    public abstract class App
    {
        private readonly Module _module;

        protected App()
        {
           _module = new Module(this.GetType().FullName); 

            Service<RouteProvider>();
        }

        protected void Service<T>()
        {
             var type = typeof(T);
             var parameters = Angular.GlobalApi.Injector().Annotate(type.GetConstructorFunction());         
             type.ToFunction().CreateFunctionCall(parameters); // only used to fix the "_" to "$" in type.$inject
             string servicename = typeof(T).Name;        
             _module.Service(servicename,type);
        }

          public static void Config<T>(this Module module)
          {
             Type type = typeof(T);
             Function fun = type.BuildControllerFunction(ThisMode.NewObject);                
             var parameters = type.ReadInjection();         
             var fcall = fun.CreateFunctionCall(parameters);         
             Config(module,fcall);
          }
    }
}