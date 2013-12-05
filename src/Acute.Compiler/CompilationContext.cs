using Roslyn.Compilers.CSharp;

namespace Acute.Compiler
{
    internal class CompilationContext
    {
        /// <summary>
        /// The compilation input object.
        /// </summary>
        public CompilationRequest Input { get; set; }

        public Compilation Compilation { get; set; }
    }
}