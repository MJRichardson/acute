using System;

namespace Acute
{
    [Flags]
    public enum DirectiveDomTypes
    {
        Attribute = 1,
        Element = 2,
        Class = 4
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class DirectiveDomTypesAttribute : Attribute
    {
        public DirectiveDomTypes DomTypes { get; private set; }

        public DirectiveDomTypesAttribute(DirectiveDomTypes domTypes)
        {
            DomTypes = domTypes;
        }
    }
}