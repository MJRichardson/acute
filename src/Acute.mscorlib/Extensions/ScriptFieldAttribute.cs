
namespace System
{
    /// <summary>
    /// Specifies that a property should render as a field in script.
    /// </summary>
    [Extension(
        "Acute.Compiler",
        "Blade.Compiler.Extensibility.ScriptFieldExtension")]
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ScriptFieldAttribute : Attribute
    {
    }
}