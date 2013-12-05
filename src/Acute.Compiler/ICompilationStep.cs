namespace Acute.Compiler
{
    internal interface ICompilationStep
    {
        void Execute(CompilationContext context);
    }
}