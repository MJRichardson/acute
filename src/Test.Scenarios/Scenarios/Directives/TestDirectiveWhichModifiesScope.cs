using Acute;

namespace Test.Scenarios.Directives
{
    public class TestDirectiveWhichModifiesScope : Directive
    {
        public TestDirectiveWhichModifiesScope(Scope scope)
        {
            scope.Model.DuckCount = 5;
        }

        protected override string Template
        {
            get { return "{{DuckCount}} little ducks went out one day"; }
        }
    }
}