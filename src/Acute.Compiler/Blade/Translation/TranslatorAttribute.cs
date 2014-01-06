using System;
using System.ComponentModel.Composition;

namespace Blade.Compiler.Translation
{
    /// <summary>
    /// For use internally to easily export a translator object via MEF.
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    internal class TranslatorAttribute : ExportAttribute, ITranslatorMetadata
    {

        public const string TranslatorContractName = "Acute.Compiler.Translation.Translator";

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        public TranslatorAttribute(Type modelType)
            : base(TranslatorContractName, typeof(ITranslator))
        {
            ModelType = modelType;
        }

        public Type ModelType { get; set; }
    }
}
