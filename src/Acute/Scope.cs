using System.Runtime.CompilerServices;

namespace Acute
{
    public interface IScope
    {
        dynamic Model { get; } 
    }

    public class Scope : IScope
    {
        [ScriptName(AngularScopeScriptName)]
        private readonly Angular.Scope _scope;

        internal const string AngularScopeScriptName = "_scope";

        [Reflectable]
        internal Scope(Angular.Scope scope)
          {
              _scope = scope;
          }

        public dynamic Model { get { return _scope; }  }
    }
}