using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
            return type.GetFunction("controller");
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

        public static object CreateFunctionCall(this Function fun, List<string> parameters) 
      {
         // if no parameters, takes function out of the array
         if(parameters.Count==0) return fun;

         // builds array, but also FIX $injection in the type
         var result = new List<object>();
         for(int t=0;t<parameters.Count;t++)
         {
            if(parameters[t].StartsWith("_")) parameters[t] = "$" + parameters[t].Substring(1);
            result.Add(parameters[t]);
         }                           
         result.Add(fun);
         return result;
      }      
    }
}