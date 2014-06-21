using System;

namespace Acute
{
    public enum DirectivePropertyBindingType
    {
        Bound,
        Evaluated  
    }

    public class DirectivePropertyBindingTypeAttribute : Attribute
    {
        public DirectivePropertyBindingTypeAttribute(DirectivePropertyBindingType bindingType)
        {
            BindingType = bindingType;
        }

        public DirectivePropertyBindingType BindingType { get; private set; }
    }
}