using System.Collections.Generic;

namespace Acute.Compiler
{
    public class CompileOptions
    {
        public IEnumerable<string> SourcePaths { get; set; }
        public IEnumerable<string> ReferencePaths { get; set; }
        public string OutputAssemblyPath { get; set; }
        public string OutputScriptPath { get; set; }

        public CompileOptions(IEnumerable<string> sourcePaths, IEnumerable<string> referencePaths,  string outputAssemblyPath, string outputScriptPath)
        {
            SourcePaths = sourcePaths;
            ReferencePaths = referencePaths;
            OutputAssemblyPath = outputAssemblyPath;
            OutputScriptPath = outputScriptPath;
        }
    }
}