using Acute;

namespace Test.Scenarios.Directives
{
    [DirectiveDomTypes(DirectiveDomTypes.Class)]
    [BindDomAttributeToDirectiveScope("MiceCount", DomAttributeBindingType.Bound)]
    public class TestDirectiveRestrictedToClass : Directive
    {
        public override string Template
        {
            get { return "{{MiceCount}} blind mice"; }
        }
    }
}