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
            Service<IRouteArgs, Acute.Services.RouteArgs>();
            Service<Acute.Scope>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsSubclassOf(typeof(Acute.Directive)))
                        Directive(type);

                   if (type.IsSubclassOf(typeof(Acute.Controller))) 
                       Controller(type);
                }
            }

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
             var func = Acute.Controller.BuildControllerFunction(controllerType);     
             _module.Controller(controllerType.AsAngularServiceName(), func);
        }

        protected void Directive(Type directiveType)
        {
            var func = Acute.Directive.BuildDirectiveFunction(directiveType);     
           _module.Directive(directiveType.AsAngularDirectiveName(), func); 
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