using System;
using System.Reflection;

namespace Acute
{
    internal class Bootstrapper
    {
        public static void Main()
        {
           Init(); 
        }

        private static void Init()
        {
           foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
           {
               if (type.IsSubclassOf(typeof (App)) == false)
                   continue;

               Activator.CreateInstance(type);

           }
        }
    }
}