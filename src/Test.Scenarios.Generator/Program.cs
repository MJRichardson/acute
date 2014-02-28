﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Acute;
using Acute.Compiler;
using Saltarelle.Compiler.SCExe;

namespace Test.Scenarios.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string exeLocationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var scenarioPaths = Directory.GetDirectories(Path.Combine(exeLocationPath, "Scenarios"));


            //foreach (var scenarioPath in scenarioPaths)
            //{
            //    var scenarioName = Path.GetFileName(scenarioPath);
            //    var sourcePaths = Directory.GetFiles(scenarioPath, "*.cs", SearchOption.AllDirectories);
            //    var referencePaths = new List<string>
            //        {
            //           typeof(App).Assembly.Location,
            //           Path.Combine(Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location), @"..\..\..\..\submodules\saltarelle.compiler\Runtime\CorLib\bin\mscorlib.dll")
            //        };

            //    compiler.Compile(new CompilationRequest(sourcePaths, referencePaths, scenarioName));

            //}

            var referencePaths = new List<string>
                {
                   typeof(App).Assembly.Location,
                   Path.Combine(Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location), @"..\..\..\..\submodules\saltarelle.compiler\Runtime\CoreLib\bin\mscorlib.dll")
                };

            Acute.Compiler.Driver.Compile(new CompileOptions(
                                             Directory.GetFiles(exeLocationPath, "*.cs", SearchOption.AllDirectories),
                                              //scenarioPaths.SelectMany(
                                              //    scenarioPath =>
                                              //    Directory.GetFiles(scenarioPath, "*.cs", SearchOption.AllDirectories)),
                                              referencePaths,
                                              Path.Combine(exeLocationPath, "Scenarios.dll"),
                                              Path.Combine(exeLocationPath, "scenarios.js")

                                              ), new ExecutableErrorReporter(Console.Out));
        }
    }
}
