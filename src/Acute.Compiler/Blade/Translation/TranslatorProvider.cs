using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using Blade.Compiler.Models;

namespace Blade.Compiler.Translation
{
    /// <summary>
    /// Provides methods for importing and resolving translators by model type.
    /// </summary>
    internal sealed class TranslatorProvider //: GenericImportProvider<ITranslator>
    {


        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="importAssemblies">The reference assemblies to import against.</param>
        public TranslatorProvider(IEnumerable<Assembly> importAssemblies = null)
            //: base(importAssemblies)
        {
            var list = (importAssemblies ?? Enumerable.Empty<Assembly>()).ToList();

            var thisAssembly = Assembly.GetExecutingAssembly();
            if (!list.Contains(thisAssembly))
                list.Add(thisAssembly);

            // create MEF container
             var container = new CompositionContainer(new AggregateCatalog(
                list.Select(a => new AssemblyCatalog(a))));

            _exports = container.GetExports<ITranslator, ITranslatorMetadata>().ToList();
        }

        /// <summary>
        /// Resolves a single import by type.
        /// </summary>
        public ITranslator ResolveTranslator(IModel model)
        {
            var customScriptTranslator = ResolveCustomScriptTranslator(model);

            if (customScriptTranslator != null)
                return customScriptTranslator;
        }

        private ITranslator ResolveGeneralTranslator(IModel model)
        {
            
        }

        private ITranslator ResolveCustomScriptTranslator(IModel model)
        {
            //if the model is an invocation expression 
            var invocationExpressionModel = model as InvocationExpression;
            if (invocationExpressionModel != null)
            {
                //if we are invoking a member on a custom-script-type
                var memberAccessExpression = invocationExpressionModel.Expression as MemberAccessExpression;

                if (memberAccessExpression != null)
                {
                    var memberDefinition = memberAccessExpression.Member.Definition as IMemberDefinition;

                    if (memberDefinition != null)
                    {
                        var customScriptType = memberDefinition.ContainingType as CustomScriptTypeDefinition;

                        if (customScriptType != null)
                        {
                            //get translator
                           var customScriptTranslatorExport =  _exports.SingleOrDefault(
                                x => !string.IsNullOrEmpty(x.Metadata.CustomScriptType) && x.Metadata.CustomScriptType == customScriptType.GetFullName());

                            return customScriptTranslatorExport != null
                                       ? customScriptTranslatorExport.Value
                                       : null;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the generic base type definition.
        /// </summary>
        protected override Type BaseType
        {
            get { return typeof(Translator<>); }
        }

        private readonly IEnumerable<Lazy<ITranslator, ITranslatorMetadata>> _exports { get; set; }

    }
}
