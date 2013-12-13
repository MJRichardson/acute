namespace System
{
    /// <summary>
    /// Specifies that a member should be injected by Angular 
    /// </summary>
    [Extension(
        "Acute.Compiler",
        "Acute.Compiler.Extensibility.AngularInjectExtension")]
    [AttributeUsage( AttributeTargets.Field | AttributeTargets.Property )]
    public class AngularInjectAttribute : Attribute
    {
        public AngularInjectAttribute(string scriptName)
        {
            
        }
    }
}