
namespace System
{
    /// <summary>
    /// Specifies that the namespace should be ingored when generating script.
    /// </summary>
    [Extension(
        "Acute.Compiler",
        "Blade.Compiler.Extensibility.ScriptIgnoreNamespaceExtension")]
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct)]
    public sealed class ScriptIgnoreNamespaceAttribute : Attribute
    {
    }
}