using Blade.Compiler.Models;
using Roslyn.Compilers.CSharp;

namespace Blade.Compiler.Translation.CustomScripts
{
    [CustomScriptTypeTranslator("Acute.RouteConfig")]
    internal class RouteConfigCustomTranslator : CustomScriptTypeTranslator
    {
        protected override void TranslateNew(Models.NewExpression model, TranslationContext context)
        {
            context.Write("{ controller:");

            context.Write(((NamedTypeSymbol) model.Type.Symbol).TypeArguments[0].GetFullName());

            context.Write("}");
         
        }

    }
}