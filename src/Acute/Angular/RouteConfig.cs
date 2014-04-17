using System;
using System.Runtime.CompilerServices;

namespace Acute.Angular
{
    [Serializable]
    [Imported]
    internal class RouteConfig
    {
      [ScriptName("controller")]     
      public String Controller;

      [ScriptName("templateUrl")]    
      public string TemplateUrl;
    }
}