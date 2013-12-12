namespace System
{
    /// <summary>
    /// Specifies that a member should be injected by Angular 
    /// </summary>
    [Extension(
        "Blade.Compiler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        "Acute.Compiler.Extensibility.AngularInjectExtension")]
    [AttributeUsage( AttributeTargets.Field | AttributeTargets.Property )]
    public class AngularInjectAttribute : Attribute
    {
        public AngularInjectAttribute(string scriptName)
        {
            
        }
    }
}