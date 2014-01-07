using Blade.Compiler.Models;

namespace Blade.Compiler.Translation
{
    [Translator(typeof(TypeOfExpression))]
    internal class TypeOfExpressionTranslater : Translator<TypeOfExpression>
    {
        public override void Translate(TypeOfExpression model, TranslationContext context)
        {
            context.Write(string.Format("new Type('{0}')", model.Target.Symbol.GetFullName()));
        }
    }
}