using Roslyn.Compilers.CSharp;

namespace Acute.Compiler
{
    internal class CompilationContext
    {
        public CompilationContext(CompilationRequest input)
        {
            Input = input;
        }

        /// <summary>
        /// The compilation input object.
        /// </summary>
        public CompilationRequest Input { get; private set; }

        public Compilation Compilation { get; set; }
    }
}