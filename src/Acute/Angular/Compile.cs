using System.Runtime.CompilerServices;

namespace Acute.Angular
{
    [AngularService(AngularServices.Compile)]
    internal class Compiler
    {
        [InlineCode("{this}({element})({scope})")] 
        public void Compile(object element, object scope)
        {
            return;
        }
    }
}