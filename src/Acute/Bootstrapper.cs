using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Acute
{
    [Mixin("Acute")]
    internal static class Bootstrapper
    {
        [ScriptName("Bootstrap")]
        public static void Bootstrap()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                   if (type.IsSubclassOf(typeof(Acute.App))) 
                       Activator.CreateInstance(type);
                }
            }
        }
    }
}