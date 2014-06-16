using Acute;

namespace Test.Scenarios.Directives
{
    public class TestDirective : Directive
    {
        public override string Template
        {
            get { return "three blind mice"; }
        }
    }
}