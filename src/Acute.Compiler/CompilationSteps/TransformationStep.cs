using System;
using System.Linq;
using Blade.Compiler;
using Blade.Compiler.Models;
using Blade.Compiler.Transformation.CSharp;

namespace Acute.Compiler.CompilationSteps
{
    internal class TransformationStep : ICompilationStep
    {
        public void Execute(CompilationContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (context.Compilation == null)
                return;

            if (context.Model == null)
                context.Model = new CompilationModel();

            var transformer = new Transformer();

            foreach (var syntaxTree in context.Compilation.SyntaxTrees)
            {
                var root = syntaxTree.GetRoot();

                if (root == null)
                    continue;

                transformer.Semantics = context.Compilation.GetSemanticModel(syntaxTree);
                var model = transformer.Visit(root).Single() as CompilationModel;

                context.Model.Merge(model);
            }

            if (!context.Result.HasErrors)
            {
                ModelRegistry.Current.ExtendCompilation(context.Model, context.Compilation.Assembly);
            }
        }
    }
}