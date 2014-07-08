using Acute;

namespace Test.Scenarios.Directives
{
    [DirectiveDomTypes(DirectiveDomTypes.Attribute)]
    public class TestDirectiveRestrictedToAttribute : Directive
    {
        protected override string Template
        {
            get { return "incy wincy spider"; }
        }
    }
}