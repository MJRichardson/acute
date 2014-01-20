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

            RegisterControllers(_module);

            Service<RouteProvider>();

            //register the config
            var configFunc = typeof (App).GetFunction("Config");
            GlobalApi.Injector().Annotate(configFunc);
            _module.Config(configFunc);

        }


        protected void Service<T>()
        {
             var type = typeof(T);
             var parameters = Angular.GlobalApi.Injector().Annotate(type.GetConstructorFunction());         
             type.ToFunction().CreateFunctionCall(parameters); // only used to fix the "_" to "$" in type.$inject
             string servicename = typeof(T).Name;        
             _module.Service(servicename,type);
        }

        private void Config(RouteProvider routeProvider)
        {
           ConfigureRoutes(routeProvider); 
        }

        protected virtual void ConfigureRoutes(RouteProvider routeProvider)
        {}

        private static void RegisterControllers(Module module)
        {
            //register controllers
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsSubclassOf(typeof (Controller)) == false)
                    continue;

             Function fun = BuildControllerFunction(type);     
             var parameters = type.ReadInjection();         
             var fcall = fun.CreateFunctionCall(parameters);         
             module.Controller(type.Name,fcall);
            }
            
        }

        private static Function BuildControllerFunction(Type type)
        {
             string body = "";
             const string scopeVar = "$scope";  


             // takes method into $scope, binding "$scope" to "this"                 
             foreach(string funcname in type.GetInstanceMethodNames())
             {
                body += String.Format("{2}.{1} = {0}.prototype.{1}.bind({2});\r\n",type.FullName,funcname,scopeVar);             
             }

             // put call at the end so that methods are defined first
             body+=String.Format("{0}.apply({1},arguments);\r\n",type.FullName,scopeVar);

            //get the constructor parameters
             var parameters = GlobalApi.Injector().Annotate(type.GetConstructorFunction());
            //and add $scope as a parameter
            parameters.Add(scopeVar);

             return ReflectionExtensions.CreateNewFunction(parameters,body);
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