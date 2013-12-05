using System.Collections.Generic;

namespace Acute.Compiler
{
    public class CompilationRequest
    {
        public IEnumerable<string> SourcePaths { get; private set; }
        public IEnumerable<string> ReferencePaths { get; private set; } 
    }
}