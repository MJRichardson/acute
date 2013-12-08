using System.Collections.Generic;
using System.Linq;

namespace Acute.Compiler
{
    public class CompilationRequest
    {
        public CompilationRequest(IEnumerable<string> sourcePaths, IEnumerable<string> referencePaths, string targetName  )
        {
            SourcePaths = sourcePaths.ToList();
            ReferencePaths = referencePaths.ToList();
            TargetName = targetName;
        }

        public IEnumerable<string> SourcePaths { get; private set; }
        public IEnumerable<string> ReferencePaths { get; private set; }
        public string TargetName { get; private set; }
    }
}