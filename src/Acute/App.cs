using System;
using System.Reflection;
using Acute.Angular;

namespace Acute
{
    public abstract class App
    {
        private readonly Module _module;

        protected App()
        {
           _module = new Module(this.GetType().FullName); 

            //register controllers
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsSubclassOf(typeof (Controller)) == false)
                    continue;
            }

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

        protected virtual void ConfigureRoutes(RouteProvider routeProvider)
        {}

        private Function BuildControllerFunction(Type type)
        {
             string body = "";
             string thisref = "_scope";  
        }

          //private void Config<T>()
          //{
          //   Type type = typeof(T);
          //   Function fun = type.BuildControllerFunction(ThisMode.NewObject);                
          //   var parameters = type.ReadInjection();         
          //   var fcall = fun.CreateFunctionCall(parameters);         
          //   Config(module,fcall);
          //}
    }
}