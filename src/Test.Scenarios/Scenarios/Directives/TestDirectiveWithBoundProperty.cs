using Acute;

namespace Test.Scenarios.Directives
{
    public class TestDirectiveWithBoundProperty : Directive
    {
        public int MiceCount { get; set; }
        public override string Template
        {
            get { return "{{MiceCount}} blind mice"; }
        }
    }
}