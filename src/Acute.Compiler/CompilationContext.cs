using Blade.Compiler;
using Roslyn.Compilers.CSharp;

namespace Acute.Compiler
{
    internal class CompilationContext
    {
        public CompilationContext(CompilationRequest input)
        {
            Input = input;
            Result = new CompilationResult();
        }

        /// <summary>
        /// The compilation input object.
        /// </summary>
        public CompilationRequest Input { get; private set; }

        public Compilation Compilation { get; set; }

        public CompilationModel Model { get; set; }

        public CompilationResult Result { get; private set; }
    }
}