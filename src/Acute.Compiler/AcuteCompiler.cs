using Acute.Compiler.CompilationSteps;

namespace Acute.Compiler
{
    public class AcuteCompiler
    {
        private CompilationPipeline _pipeline;

        public AcuteCompiler()
        {
           _pipeline = new CompilationPipeline(); 
            _pipeline.AddStep(new SyntaxParseStep());
        }

         public void Compile(CompilationRequest request)
         {
             try
             {
                 var context = new CompilationContext(request);
                 CompilationContext.Current = context;

                 _pipeline.Execute(context);
             }
             finally
             {
                 CompilationContext.Current = null;
             }

         }
    }
}