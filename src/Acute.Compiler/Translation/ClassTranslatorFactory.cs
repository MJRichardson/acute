using Blade.Compiler.Models;
using Blade.Compiler.Translation;
using Roslyn.Compilers.Common;

namespace Acute.Compiler.Translation
{
    internal class ClassTranslatorFactory
    {
        public static Translator<ClassDeclaration> CreateTranslator(ClassDeclaration declaration)
        {
            //if the class inherits from Acute.App
            if (declaration.IsDerived && InheritsFrom(declaration.Definition.Symbol, typeof (App).FullName))
                return new AppClassTranslator();

            return new ClassTranslator();
        }

        private static bool InheritsFrom(INamedTypeSymbol classDefinition, string fullName)
        {
            if (classDefinition.BaseType == null)
                return false;

            if (classDefinition.BaseType.GetFullName() == fullName)
                return true;

            return InheritsFrom(classDefinition.BaseType, fullName);

        }

    }

}