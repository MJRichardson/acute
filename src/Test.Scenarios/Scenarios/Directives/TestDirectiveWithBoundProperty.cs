using System.Runtime.CompilerServices;
using Acute;

namespace Test.Scenarios.Directives
{
    public class TestDirectiveWithBoundProperty : Directive
    {
        [Reflectable]
        public int miceCount { get; set; }

        public override string Template
        {
            get { return "{{miceCount}} blind mice"; }
        }
    }
}