using Acute;

namespace Test.Scenarios.Directives.InterDirectiveDependency
{
    [BindDomAttributeToDirectiveScope("Animal", DomAttributeBindingType.Bound)]
    public class DirectiveA : Directive
    {
        private readonly Scope _scope;

        public DirectiveA(Scope scope)
        {
            _scope = scope;
        }

        public string Animal { set { _scope.Model.Animal = value; } }

        protected override string Template
        {
            get { return "Old MacDonald has a farm, E-I-E-I-O. And on that farm he had a {{Animal}}"; }
        }

    }
}