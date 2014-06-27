using Acute;

namespace Test.Scenarios.Directives
{
    [DirectiveDomTypes(DirectiveDomTypes.Attribute)]
    public class TestDirectiveRestrictedToAttribute : Directive
    {
        public override string Template
        {
            get { return "incy wincy spider"; }
        }
    }
}