using System;
using System.Collections.Generic;
using Blade.Compiler.Models;

namespace Blade.Compiler.Translation.CustomScripts
{
    [CustomScriptTypeTranslator(RouteProviderFullName)]
    internal class RouteProviderCustomTranslator : CustomScriptTypeTranslator
    {
        private const string RouteProviderFullName = "Acute.RouteProvider";

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