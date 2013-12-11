
namespace System
{
    /// <summary>
    /// Specifies the usage of another attribute class. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public sealed class AttributeUsageAttribute : Attribute
    {
        private AttributeTargets _validOn = AttributeTargets.All;
        private bool _allowMultiple = false;
        private bool _inherited = true;

        public AttributeUsageAttribute(AttributeTargets validOn)
        {
            _validOn = validOn;
        }

        public AttributeTargets ValidOn
        {
            get { return _validOn; }
        }

        public bool AllowMultiple
        {
            get { return _allowMultiple; }
            set { _allowMultiple = value; }
        }

        public bool Inherited
        {
            get { return _inherited; }
            set { _inherited = value; }
        }
    }
}


