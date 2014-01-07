namespace System
{
    [Extension(
        "Acute.Compiler",
        "Acute.Compiler.Extensibility.CustomScriptTypeExtension")]
    [AttributeUsage( AttributeTargets.Interface | AttributeTargets.Class )]
    public class CustomScriptTypeAttribute : Attribute
    {
        public CustomScriptTypeAttribute()
        {
        } 
    }
}