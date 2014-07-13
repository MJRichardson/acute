using Acute;

namespace Test.Scenarios.Directives.InterDirectiveDependency
{
    public class DirectiveB : Directive
    {
        public DirectiveB(DirectiveA directiveA)
        {
            directiveA.Animal = "sheep";
        } 
    }
}