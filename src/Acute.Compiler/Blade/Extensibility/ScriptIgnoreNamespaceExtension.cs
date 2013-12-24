using System.Collections.Generic;
using Blade.Compiler.Models;

namespace Blade.Compiler.Extensibility
{
    internal sealed class ScriptIgnoreNamespaceExtension : Extension
    {
        public override IDefinition ExtendDefinition(IDefinition definition)
        {
            // only applies to type definitions
            var typeDef = definition as ITypeDefinition;
            if (typeDef != null)
                typeDef.Namespace = "";

            return definition;
        }
    }
}
