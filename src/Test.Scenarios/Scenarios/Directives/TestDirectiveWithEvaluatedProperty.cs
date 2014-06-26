using Acute;

namespace Test.Scenarios.Directives
{
    [BindDomAttributeToDirectiveScope("song", DomAttributeBindingType.Evaluated)]
    public class TestDirectiveWithEvaluatedProperty : Directive
    {
        public override string Template
        {
            get { return "And all the people sing '{{song}}'."; }
        }
    }
}