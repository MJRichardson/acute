using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Acute
{
    internal static class ReflectionExtensions
    {
        public static Function GetConstructorFunction(this Type type)
        {
            return (Function) type.Prototype["constructor"];
        }

        [InlineCode("{type}")]
        public static Function ToFunction(this Type type)
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