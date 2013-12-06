using System.Linq;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;

namespace Acute.Compiler.CompilationSteps
{
    internal class SyntaxParseStep : ICompilationStep
    {
        public void Execute(CompilationContext context)
        {
            if (context.Input.SourcePaths.Any() == false)
                return;

            //build syntax-trees
            var syntaxTrees = context.Input.SourcePaths.Select(x => SyntaxTree.ParseFile(x, ParseOptions.Default))
                .ToList();

            var references = context.Input.ReferencePaths.Select(x => new MetadataFileReference(x))
                            .ToList();

            context.Compilation = Compilation.Create(
                context.Input.TargetName + ".dll",
                new CompilationOptions(OutputKind.DynamicallyLinkedLibrary),
                syntaxTrees, references);
        }
    }
}