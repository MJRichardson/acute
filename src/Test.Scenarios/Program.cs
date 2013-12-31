using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Acute;
using Acute.Compiler;

namespace Test.Scenarios
{
    class Program
    {
        static void Main(string[] args)
        {
            string exeLocationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var scenarioPaths = Directory.GetDirectories(Path.Combine(exeLocationPath, "Scenarios"));

            var compiler = new AcuteCompiler();

            //foreach (var scenarioPath in scenarioPaths)
            //{
            //    var scenarioName = Path.GetFileName(scenarioPath);
            //    var sourcePaths = Directory.GetFiles(scenarioPath, "*.cs", SearchOption.AllDirectories);
            //    var referencePaths = new List<string>
            //        {
            //           typeof(App).Assembly.Location,
            //           Path.Combine(Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location), @"..\..\..\bin\mscorlib.dll")
            //        };

            //    compiler.Compile(new CompilationRequest(sourcePaths, referencePaths, scenarioName));

            //}

            var referencePaths = new List<string>
                {
                   typeof(App).Assembly.Location,
                   Path.Combine(Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location), @"..\..\..\bin\mscorlib.dll")
                };

            compiler.Compile(
                new CompilationRequest(
                    scenarioPaths.SelectMany( scenarioPath => Directory.GetFiles(scenarioPath, "*.cs", SearchOption.AllDirectories)),
                    referencePaths, 
                    "scenarios",
                    outputPath: exeLocationPath));

        }
    }
}
