using System.Runtime.CompilerServices;
using Acute;

namespace Test.Scenarios.Directives
{
    [BindDomAttributeToDirectiveScope("miceCount", DomAttributeBindingType.Bound)]
    public class TestDirectiveWithBoundProperty : Directive
    {

        public override string Template
        {
            get { return "{{miceCount}} blind mice"; }
        }
    }
}