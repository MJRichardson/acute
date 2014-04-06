
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Acute.Angular;

namespace Acute
{
    public abstract class Controller
    {
        internal const string ControlScriptName = "control";

        [ScriptName(ControlScriptName)]
        public abstract void Control(dynamic scope);

        internal static IList<object> BuildControllerFunction(Type type)
        {
             const string scopeVar = "$scope";  

            //get the constructor parameters
             var parameters = GlobalApi.Injector().Annotate(type.GetConstructorFunction());
            string body = String.Format("var controller = new {0}({1});\n", type.FullName, string.Join(",", parameters));
            body += String.Format("controller.{0}({1});\n", Acute.Controller.ControlScriptName, scopeVar);


            var functionArrayNotation = type.CreateFunctionArray(); 
            //and add $scope as a parameter
            functionArrayNotation.Insert(functionArrayNotation.Count - 1, scopeVar );

            //and add $scope as a parameter
            parameters.Add(scopeVar);

            var modifiedFunc = ReflectionExtensions.CreateNewFunction(parameters,body);
            functionArrayNotation[parameters.Count] = modifiedFunc;

            return functionArrayNotation;

            /*
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
             */
        }
    }
}