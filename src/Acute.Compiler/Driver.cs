using System.Linq;
using Saltarelle.Compiler;
using Saltarelle.Compiler.Driver;

namespace Acute.Compiler
{
    public class Driver
    {
        public static bool Compile(CompileOptions options, IErrorReporter errorReporter)
        {
            var saltarelleDriver = new CompilerDriver(errorReporter);

            var saltarelleOptions = new CompilerOptions();
            saltarelleOptions.SourceFiles.AddRange(options.SourcePaths);
            saltarelleOptions.OutputScriptPath = options.OutputScriptPath;
            saltarelleOptions.OutputAssemblyPath = options.OutputAssemblyPath;
            saltarelleOptions.References.AddRange(options.ReferencePaths.Select(x => new Reference(x)));
            saltarelleOptions.AlreadyCompiled = false;

            if (saltarelleDriver.Compile(saltarelleOptions) == false)
                return false;

            return true;
        }
    }
}