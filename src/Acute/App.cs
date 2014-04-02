using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Acute.Angular;
using Acute.Services;

namespace Acute
{
    public abstract class App
    {
        private readonly Module _module;

        protected App()
        {
           _module = new Module(this.GetType().FullName, "ngRoute", "ngCookies" ); 

            //Provider<RouteProvider>();
            RegisterRouteProvider();
            Service<IHttp, Acute.Services.Http>();
            Service<ILocation, Acute.Services.Location>();
            Service<ICookies, Acute.Services.Cookies>();

            //register the config
            //var configFunc = typeof (App).GetFunction(ConfigMethodScriptName);
            //var parameters = GlobalApi.Injector().Annotate(configFunc);
            //var annotatedFunc = configFunc.CreateFunctionCall(parameters);
            //_module.Config(annotatedFunc);

            //var configFunc = typeof (App).GetFunction(ConfigureRoutesScriptName);
            //var parameters = GlobalApi.Injector().Annotate(configFunc);
            //var annotatedFunc = configFunc.CreateFunctionArray(parameters);
            //_module.Config(annotatedFunc);

            var appType = this.GetType();
            var configMethod = appType.GetMethod("ConfigureRoutes");
            _module.Config(appType.CreateFunctionArray(configMethod));

        }

        protected void Controller<T>() where T : Controller
        {
            Controller(typeof (T));
        }

        protected void Controller(Type controllerType)
        {
             var func = BuildControllerFunction(controllerType);     
             _module.Controller(controllerType.AsAngularServiceName(), func);
        }


        protected void Service<T>()
        {
            Service<T,T>();
        }

        protected void Service<TInterface, TImplementation>()
        {
             var implementation = typeof(TImplementation);
            var contract = typeof (TInterface);
            var functionArrayNotation = implementation.CreateFunctionArray(); 
             _module.Service(contract.AsAngularServiceName(),functionArrayNotation);
        }

        private void RegisterRouteProvider()
        {
            var routeProviderType = typeof (RouteProvider);
            var functionArrayNotation = routeProviderType.CreateFunctionArray(); 
             _module.Provider("Acute.Route",functionArrayNotation);
        }

        //protected void Provider<T>()
        //{
        //     var type = typeof(T);
        //    var functionArrayNotation = type.CreateFunctionArray(); 
        //     _module.Provider(type.AsAngularServiceName(),functionArrayNotation);
        //}

        //private void Config(RouteProvider _routeProvider)
        //{
        //   ConfigureRoutes(_routeProvider); 
        //}

        [Reflectable]
        protected virtual void ConfigureRoutes(RouteProvider routeProvider)
        {}

        //private static void RegisterControllers(Module module)
        //{
        //    //register controllers
        //    foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
        //    {
        //        if (type.IsSubclassOf(typeof (Controller)) == false)
        //            continue;

        //     Function fun = BuildControllerFunction(type);     
        //     var parameters = type.ReadInjection();         
        //     var fcall = fun.CreateFunctionCall(parameters);         
        //     module.Controller(type.Name,fcall);
        //    }
            
        //}

        private static IList<object> BuildControllerFunction(Type type)
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

            var functionArrayNotation = type.CreateFunctionArray(); 
            //and add $scope as a parameter
            functionArrayNotation.Insert(functionArrayNotation.Count - 1, scopeVar );

            //and add $scope as a parameter
            parameters.Add(scopeVar);

            var modifiedFunc = ReflectionExtensions.CreateNewFunction(parameters,body);
            functionArrayNotation[parameters.Count] = modifiedFunc;

            return functionArrayNotation;
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