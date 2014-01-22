using System;
using System.Runtime.CompilerServices;

namespace Acute.Angular
{
    [Serializable]
    [Imported]
    public class RouteConfig
    {
      [ScriptName("controller")]     
      public string Controller;

      [ScriptName("templateUrl")]    
      public string TemplateUrl;
    }
}