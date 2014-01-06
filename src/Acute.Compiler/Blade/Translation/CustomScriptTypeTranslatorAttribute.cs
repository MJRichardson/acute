using System;
using System.ComponentModel.Composition;

namespace Blade.Compiler.Translation
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    internal class CustomScriptTypeTranslatorAttribute : ExportAttribute
    {
        public const string CustomScriptTypeTranslatorContractName = "Acute.Compiler.Translation.CustomScriptTypeTranslator";

        public CustomScriptTypeTranslatorAttribute(string customScriptType) : base(CustomScriptTypeTranslatorContractName, typeof(ITranslator) )
        {
            CustomScriptType = customScriptType;
        }

        public string CustomScriptType { get; set; }
    }
}