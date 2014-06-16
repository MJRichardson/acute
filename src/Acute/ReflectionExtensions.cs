using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Acute.Angular;

namespace Acute
{
    //todo: rename this class
    internal static class ReflectionExtensions
    {
        public static Function GetFunction(this Type type, string functionName)
        {
            return (Function) type.Prototype[functionName];
        }

        public static Function GetConstructorFunction(this Type type)
        {
            return type.GetFunction("constructor");
        }

        public static string AsAngularServiceName(this Type type)
        {
            var angularServiceAttributes = type.GetCustomAttributes(typeof (AngularServiceAttribute), false);

            return angularServiceAttributes.Length > 0
                ? ((AngularServiceAttribute) angularServiceAttributes[0]).ServiceName
                : type.FullName;
        }

        public static string AsAngularDirectiveName(this Type type)
        {
            //todo: allow attribute to override
            var undotted =  type.FullName.Replace(".", "");
            var firstCharLower = undotted[0].ToString().ToLower();
            return firstCharLower + undotted.Substring(1);
        }

        public static List<string> GetInstanceMethodNames(this Type type)
        {
            var result = new List<string>();
            foreach (string key in type.Prototype.Keys)
            {
                if (key != "constructor") result.Add(key);
            }
            return result;
        }

        [InlineCode("{type}")]
        public static Function ToFunction(this Type type)
        {
            return null;
        }

        [InlineCode("{type}.$inject")]
        public static List<string> ReadInjection(this Type type)
        {
            return null;
        }

        [InlineCode("new Function({args},{body})")]
        public static Function CreateNewFunction(List<string> args, string body)
        {
            return null;
        }

      //  public static object CreateFunctionArray(this Function fun, List<string> parameters) 
      //{
      //   // if no parameters, takes function out of the array
      //   if(parameters.Count==0) return fun;

      //   // builds array, but also FIX $injection in the type
      //   var result = new List<object>();
      //   for(int t=0;t<parameters.Count;t++)
      //   {
      //      if(parameters[t].StartsWith("_")) parameters[t] = "$" + parameters[t].Substring(1);
      //      result.Add(parameters[t]);
      //   }                           
      //   result.Add(fun);
      //   return result;
      //}      

        public static IList<object> CreateFunctionArray(this Type type)
        {
            var constructorInfo = type.GetConstructors()[0]; //todo: assert only one constructor
            //var constructorInfo = type.GetMember(null, BindingFlags.Default)[0];

            return type.CreateFunctionArray((MethodBase)constructorInfo);
        }

        public static IList<object> CreateFunctionArray(this Type type, MethodBase method)
        {
            var func = method is ConstructorInfo
                           ? type.GetConstructorFunction()
                           : type.GetFunction(((MethodInfo) method).ScriptName); 

            var parameterTypes = method.ParameterTypes;

            var functionArrayNotation = new List<object>();
            foreach (var parameterType in parameterTypes)
            {
                functionArrayNotation.Add(parameterType.AsAngularServiceName());
            }

            functionArrayNotation.Add(func);

            return functionArrayNotation;
        }
    }
}