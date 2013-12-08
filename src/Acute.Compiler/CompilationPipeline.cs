using System.Collections.Generic;

namespace Acute.Compiler
{
    internal class CompilationPipeline
    {
        public CompilationContext Execute(CompilationContext compilationContext)
        {
           foreach (var step in _steps)
           {
              step.Execute(compilationContext); 
           }

            return compilationContext;
        }

         public void AddStep(ICompilationStep step)
         {
            _steps.Add(step); 
         }

        private readonly List<ICompilationStep> _steps = new List<ICompilationStep>();
    }
}