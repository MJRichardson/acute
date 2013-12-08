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
             var context = new CompilationContext(request);
             _pipeline.Execute(context);

         }
    }
}