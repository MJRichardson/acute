using System.Runtime.CompilerServices;

namespace Acute
{
    public sealed class Scope  
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