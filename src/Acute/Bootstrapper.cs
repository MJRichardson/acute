using System;
using System.Reflection;

namespace Acute
{
    public class Bootstrapper
    {
        public static void Init()
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