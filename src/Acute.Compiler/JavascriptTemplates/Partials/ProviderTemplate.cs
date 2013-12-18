namespace Acute.Compiler.JavascriptTemplates
{
    internal partial class ProviderTemplate
    {
        public string ModuleName { get; private set; }
        public string ServiceName { get; private set; }
        public string[] Dependencies { get; private set; }

        public ProviderTemplate(string moduleName, string serviceName, params string[] dependencies)
        {
            ModuleName = moduleName;
            ServiceName = serviceName;
            Dependencies = dependencies;
        }
    }
}