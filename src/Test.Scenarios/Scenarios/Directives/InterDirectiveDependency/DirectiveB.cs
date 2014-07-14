using Acute;

namespace Test.Scenarios.Directives.InterDirectiveDependency
{
    [BindDomAttributeToDirectiveScope("Animal", DomAttributeBindingType.Evaluated)]
    public class DirectiveB : Directive
    {
        public DirectiveB(Scope scope, DirectiveA directiveA)
        {
            directiveA.Animal = scope.Model.Animal;
        } 
    }
}