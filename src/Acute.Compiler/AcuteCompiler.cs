using System;
using System.IO;
using System.Reflection;
using System.Text;
using Acute.Compiler.CompilationSteps;
using Blade.Compiler.Models;

namespace Acute.Compiler
{
    public class AcuteCompiler
    {
        private CompilationPipeline _pipeline;

        public AcuteCompiler()
        {
           _pipeline = new CompilationPipeline(); 
            _pipeline.AddStep(new SyntaxParseStep());
            _pipeline.AddStep(new TransformStep());
            _pipeline.AddStep(new TranslateStep());
        }

         public void Compile(CompilationRequest request)
         {
             try
             {
                 var context = new CompilationContext(request);
                 CompilationContext.Current = context;

                 ModelRegistry.BeginRegistration();

                 string outputFileName = request.TargetName + ".js";
                 string outputFilePath = !string.IsNullOrEmpty(request.OutputPath)
                                             ? Path.Combine(request.OutputPath, outputFileName)
                                             : outputFileName; 



                 using (context.OutputStream = File.Create(outputFilePath))
                 {
                     CopyEmbeddedFileContentsToStream("Acute.Compiler.JavascriptTemplates.angular.min.js", context.OutputStream);
                     CopyEmbeddedFileContentsToStream("Acute.Compiler.JavascriptTemplates.blade.js", context.OutputStream);
                     CopyEmbeddedFileContentsToStream("Acute.Compiler.JavascriptTemplates.acute.js", context.OutputStream);

                     _pipeline.Execute(context);
                 }
             }
             finally
             {
                 ModelRegistry.EndRegistration();
                 CompilationContext.Current = null;
             }

         }

        private static void CopyEmbeddedFileContentsToStream(string resourceName, Stream outputStream)
        {
             using (var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
             {
                 using (var streamReader = new StreamReader(resourceStream))
                 {
                     var contents = Encoding.UTF8.GetBytes(streamReader.ReadToEnd());
                     outputStream.Write(contents, 0, contents.Length);
                 }
             }
        }
    }
}