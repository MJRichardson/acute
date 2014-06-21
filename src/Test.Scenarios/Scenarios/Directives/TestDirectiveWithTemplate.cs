using Acute;

namespace Test.Scenarios.Directives
{
    public class TestDirectiveWithTemplate : Directive
    {
        public override string Template
        {
            get { return "three blind mice"; }
        }
    }
}