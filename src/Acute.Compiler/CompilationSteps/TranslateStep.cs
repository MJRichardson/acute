using System.Linq;
using Acute.Compiler.Translation;
using Blade.Compiler;
using Blade.Compiler.Translation;

namespace Acute.Compiler.CompilationSteps
{
    internal class TranslateStep : ICompilationStep
    {
        public void Execute(CompilationContext context)
        {
            if (context == null || context.Model == null)
                return;

            if (context.OutputStream == null || !context.OutputStream.CanWrite)
                throw new CompilationException("The translation output stream is null or not writable.");

            var translationCtx = new TranslationContext {OutputStream = context.OutputStream};

            // write enum declarations
            var enumTranslator = new EnumTranslator();
            foreach (var item in context.Model.Enums)
                enumTranslator.Translate(item, translationCtx);

            // write class declarations
            foreach (var item in ClassSorter.Sort(context.Model.Classes))
            {
                var classTranslator = ClassTranslatorFactory.CreateTranslator(item);
                classTranslator.Translate(item, translationCtx);
            }

            // write global statements
            if (context.Model.GlobalStatements.Any())
            {
                translationCtx.WriteLine();
                translationCtx.IsWritingGlobalStatements = true;
                foreach (var item in context.Model.GlobalStatements)
                    translationCtx.WriteModel(item);
                translationCtx.IsWritingGlobalStatements = false;
            }

        }
    }
}