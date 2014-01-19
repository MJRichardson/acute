using System;
using System.Runtime.CompilerServices;

namespace Acute.Angular
{
   [Imported]
    internal sealed class Module
    {
      [InlineCode("angular.module({name},[])")] 
       public Module(string name)
       {
           
       } 

      [InlineCode("angular.module({moduleName},{requires})")]
      public Module(string moduleName, params string[] requires)
      {         
      }

      [InlineCode("{module}.config({func})")]
      public static void Config(Module module, object func)
      {
      }    

      [InlineCode("{module}.controller({Name},{func})")]
      public static void Controller(Module module, string Name, object func)
      {
      } 

      [InlineCode("{this}.service({Name},{func})")]
      public void Service(string Name, Type func)
      {
      }          

    }
}