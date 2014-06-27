using Acute;

namespace Test.Scenarios.Directives
{
    [DirectiveDomTypes(DirectiveDomTypes.Element)]
    public class TestDirectiveRestrictedToElement : Directive
    {
        public override string Template
        {
            get { return "incy wincy spider"; }
        }
    }
}