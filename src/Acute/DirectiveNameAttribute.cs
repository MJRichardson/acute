using System;

namespace Acute
{
    public class DirectiveNameAttribute : Attribute
    {
        public string Name { get; private set; }

        public DirectiveNameAttribute(string name)
        {
            Name = name;
        }
    }
}