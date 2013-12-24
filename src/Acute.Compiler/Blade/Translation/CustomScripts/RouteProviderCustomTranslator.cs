using System;
using System.Collections.Generic;
using Blade.Compiler.Models;

namespace Blade.Compiler.Translation.CustomScripts
{
    internal class RouteProviderCustomTranslator
    {
        private const string RouteProviderFullName = "Acute.RouteProvider";

         public Action<InvocationExpression, IEnumerable<ExpressionModel>,  TranslationContext> Transalation(string methodName)
         {
             if (methodName == "When")
                 return TranslateWhen;

             return null;
         }

        private static void TranslateWhen(InvocationExpression model, IEnumerable<ExpressionModel> arguments,  TranslationContext context)
        {
            context.Write(RouteProviderFullName + ".when(");
            context.WriteModels(arguments, ",");
            context.Write(")");
        }
    }
}