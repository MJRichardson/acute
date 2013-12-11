using Blade.Compiler.Translation;

namespace Acute.Compiler.Translation
{
    internal class AppClassTranslator : ClassTranslator
    {
        public override void Translate(Blade.Compiler.Models.ClassDeclaration model, TranslationContext context)
        {
            base.Translate(model, context);
        }
    }
}