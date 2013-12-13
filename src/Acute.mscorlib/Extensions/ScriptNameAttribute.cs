﻿
namespace System
{
    /// <summary>
    /// Specifies that a target should use an alternate name in script.
    /// </summary>
    [Extension(
        "Acute.Compiler",
        "Blade.Compiler.Extensibility.ScriptNameExtension")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Event | AttributeTargets.Field |
        AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Struct)]
    public sealed class ScriptNameAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="name">The name to use in script.</param>
        public ScriptNameAttribute(string name)
        {
        }
    }
}