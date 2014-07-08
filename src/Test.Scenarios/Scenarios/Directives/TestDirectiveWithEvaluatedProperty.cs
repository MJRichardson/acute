using Acute;

namespace Test.Scenarios.Directives
{
    [BindDomAttributeToDirectiveScope("song", DomAttributeBindingType.Evaluated)]
    public class TestDirectiveWithEvaluatedProperty : Directive
    {
        protected override string Template
        {
            get { return "And all the people sing '{{song}}'."; }
        }
    }
}