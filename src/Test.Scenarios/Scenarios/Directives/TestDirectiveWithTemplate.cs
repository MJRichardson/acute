using Acute;

namespace Test.Scenarios.Directives
{
    public class TestDirectiveWithTemplate : Directive
    {
        protected override string Template
        {
            get { return "three blind mice"; }
        }
    }
}