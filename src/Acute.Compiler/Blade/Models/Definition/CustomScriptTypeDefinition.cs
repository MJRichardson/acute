using Roslyn.Compilers.Common;

namespace Blade.Compiler.Models
{
    public sealed class CustomScriptTypeDefinition : ContainerTypeDefinition
    {
        public CustomScriptTypeDefinition(TypeDefinitionKind typeKind, INamedTypeSymbol symbol = null) : base(symbol)
        {
            TypeKind = typeKind;
        } 
    }
}