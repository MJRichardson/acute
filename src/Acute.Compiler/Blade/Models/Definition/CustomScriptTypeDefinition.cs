using Roslyn.Compilers.Common;

namespace Blade.Compiler.Models
{
    public sealed class CustomScriptTypeDefinition : InterfaceDefinition
    {
        public CustomScriptTypeDefinition(INamedTypeSymbol symbol = null) : base(symbol)
        {
            
        } 
    }
}