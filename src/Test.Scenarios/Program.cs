using System;
using System.Collections.Generic;
using System.IO;
using Acute.Compiler;

namespace Test.Scenarios
{
    class Program
    {
        static void Main(string[] args)
        {
            var scenarioPaths = Directory.GetDirectories(Path.Combine(Environment.CurrentDirectory, "Scenarios"));

            var compiler = new AcuteCompiler();

            foreach (var scenarioPath in scenarioPaths)
            {
                var scenarioName = Path.GetFileName(scenarioPath);
                var sourcePaths = Directory.GetFiles(scenarioPath, "*.cs", SearchOption.AllDirectories);
                var referencePaths = new List<string>();

                compiler.Compile(new CompilationRequest(sourcePaths, referencePaths, scenarioName));

            }

        }
    }
}
