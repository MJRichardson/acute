using Acute;

namespace Test.Scenarios.Directives
{
    [DirectiveDomTypes(DirectiveDomTypes.Element)]
    public class TestDirectiveRestrictedToElement : Directive
    {
        protected override string Template
        {
            get { return "incy wincy spider"; }
        }
    }
}