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
    }
}