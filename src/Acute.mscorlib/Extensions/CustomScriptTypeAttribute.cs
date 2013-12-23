namespace System
{
    [Extension(
        "Acute.Compiler",
        "Acute.Compiler.Extensibility.CustomScriptTypeExtension")]
    [AttributeUsage( AttributeTargets.Interface)]
    public class CustomScriptTypeAttribute : Attribute
    {
        public CustomScriptTypeAttribute(string customTranslator)
        {
            
        } 
    }
}