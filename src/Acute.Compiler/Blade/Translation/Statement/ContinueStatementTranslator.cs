using Blade.Compiler.Models;

namespace Blade.Compiler.Translation
{
    /// <summary>
    /// Handles translation of continue statement models.
    /// </summary>
    [Translator(typeof(ContinueStatement))]
    internal class ContinueStatementTranslator : Translator<ContinueStatement>
    {
        public override void Translate(ContinueStatement model, TranslationContext context)
        {
            context.EnsureLineBreak();
            context.WriteLine("continue;");
        }
    }
}
