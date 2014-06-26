using System;

namespace Acute
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class BindDomAttributeToDirectiveScopeAttribute : Attribute
    {
        public string PropertyName { get; private set; }
        public string AttributeName { get; private set; }
        public DomAttributeBindingType BindingType { get; private set; }

        public BindDomAttributeToDirectiveScopeAttribute(string propertyName, DomAttributeBindingType bindingType) 
            :this(propertyName, propertyName, bindingType)
            
        {
        }

        public BindDomAttributeToDirectiveScopeAttribute(string propertyName, string attributeName, DomAttributeBindingType bindingType)
        {
            PropertyName = propertyName;
            AttributeName = attributeName.FirstCharToLower();
            BindingType = bindingType;
        }
    }
}