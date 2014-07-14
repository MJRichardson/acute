using System.Runtime.CompilerServices;
using Acute;

namespace Test.Scenarios.Directives
{
    [BindDomAttributeToDirectiveScope("lowercaseword", DomAttributeBindingType.Bound)]
    [BindDomAttributeToDirectiveScope("Uppercaseword", DomAttributeBindingType.Bound)]
    [BindDomAttributeToDirectiveScope("multiWordCamelCase", DomAttributeBindingType.Bound)]
    [BindDomAttributeToDirectiveScope("MultiWordPascalCase", DomAttributeBindingType.Bound)]
    public class TestDirectiveWithBoundProperties : Directive
    {
        protected override string Template
        {
            get { return "{{lowercaseword}} {{Uppercaseword}} {{multiWordCamelCase}} {{MultiWordPascalCase}}"; }
        }
    }
}