using Blade.Compiler.Extensibility;
using Blade.Compiler.Models;
using Roslyn.Compilers.Common;

namespace Acute.Compiler.Extensibility
{
    public class CustomScriptTypeExtension : Extension
    {
        public override IDefinition ExtendDefinition(Blade.Compiler.Models.IDefinition definition)
        {
            var typeDef = definition as ContainerTypeDefinition;

            if (typeDef == null)
                return definition;

            return new CustomScriptTypeDefinition(typeDef.TypeKind, (INamedTypeSymbol)definition.Symbol);

        }
    }
}