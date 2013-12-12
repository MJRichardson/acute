using System.IO;
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

                 using (context.OutputStream = File.Create(request.TargetName + ".js"))
                 {
                     _pipeline.Execute(context);
                 }
             }
             finally
             {
                 ModelRegistry.EndRegistration();
                 CompilationContext.Current = null;
             }

         }
    }
}