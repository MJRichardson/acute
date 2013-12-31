using System.Collections.Generic;

namespace Acute.Compiler.JavascriptTemplates
{
    internal partial class module
    {
        public string ModuleName { get; private set; }
        public string ConfigBody { get; private set; }
        public IEnumerable<string> ConfigDependencies { get; private set; }
        public IEnumerable<string> Parameters { get; private set; }

        public module(string moduleName, string configBody, IEnumerable<string> configDependencies, IEnumerable<string> parameters )
        {
            ModuleName = moduleName;
            ConfigBody = configBody;
            ConfigDependencies = configDependencies;
            Parameters = parameters;
        }
    }
}