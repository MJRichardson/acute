namespace Acute
{
    public abstract class Directive
    {
        public virtual string Template { get { return null; } } 
        public virtual string TemplateUrl { get { return null; } } 
    }
}