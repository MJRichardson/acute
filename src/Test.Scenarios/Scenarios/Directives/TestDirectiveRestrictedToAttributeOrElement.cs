using Acute;

namespace Test.Scenarios.Directives
{
    [DirectiveDomTypes(DirectiveDomTypes.Attribute | DirectiveDomTypes.Element)]
    public class TestDirectiveRestrictedToAttributeOrElement : Directive
    {
        protected override string Template
        {
            get { return "incy wincy spider"; }
        }
    }
}