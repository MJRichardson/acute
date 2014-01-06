using System;
using System.Collections.Generic;
using Blade.Compiler.Models;

namespace Blade.Compiler.Translation.CustomScripts
{
    internal class RouteProviderCustomTranslator : CustomScriptTypeTranslator
    {
        private const string RouteProviderFullName = "Acute.RouteProvider";

         public Action<InvocationExpression, IEnumerable<ExpressionModel>,  TranslationContext> Transalation(string methodName)
         {
             if (methodName == "When")
                 return TranslateWhen;

             return null;
         }


        protected override void TranslateMemberInvocation(InvocationExpression model, TranslationContext context)
        {
            var memberAccessExpression = (MemberAccessExpression) model.Expression;
            var memberName = memberAccessExpression.Member.Definition.Name;

            switch (memberName)
            {
                case "When":
                   TranslateWhen(memberAccessExpression, TranslationHelper.GetInvocationArgs(model), context ); 
                    break;

                default:
                    throw new ArgumentOutOfRangeException("memberName", memberName, "Unexpected member name." ); 
            }
        }

        private static void TranslateWhen(MemberAccessExpression memberAccessExpression, IEnumerable<ExpressionModel> arguments,  TranslationContext context)
        {
            context.WriteModel(memberAccessExpression.Expression);
            context.Write(".when(");
            context.WriteModels(arguments, ",");
            context.Write(")");
        }
    }
}