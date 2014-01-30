using System;
using System.Runtime.CompilerServices;

namespace Acute.Angular
{
    [Imported]
    internal sealed class Module
    {
        [InlineCode("angular.module({name},[])")]
        public Module(string name)
        {

        }

        [InlineCode("angular.module({moduleName},{requires})")]
        public Module(string moduleName, params string[] requires)
        {
        }

        [InlineCode("{this}.config({func})")]
        public void Config(object func)
        {
        }

        [InlineCode("{this}.controller({Name},{func})")]
        public void Controller(string Name, object func)
        {
        }

        [InlineCode("{this}.service({Name},{func})")]
        public void Service(string Name, object func)
        {
        }

        [InlineCode("{this}.provider({name}, {func})")]
        public void Provider(string name, object func)
        {
        }

    }
}