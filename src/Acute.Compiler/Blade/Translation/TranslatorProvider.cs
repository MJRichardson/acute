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
    internal sealed class TranslatorProvider 
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

            _generalTranslators = container.GetExports<ITranslator, ITranslatorMetadata>(TranslatorAttribute.TranslatorContractName).ToList();
            _customScriptTypeTranslators = container.GetExports<ITranslator, ICustomScriptTypeTranslatorMetadata>(CustomScriptTypeTranslatorAttribute.CustomScriptTypeTranslatorContractName).ToList();
        }

        /// <summary>
        /// Resolves a single import by type.
        /// </summary>
        public ITranslator ResolveTranslator(IModel model)
        {
            //if there is a custom-script-translator for the type, then use it
            return ResolveCustomScriptTranslator(model) 
                //otherwise use the general translator
                ?? ResolveGeneralTranslator(model);
        }

        private ITranslator ResolveGeneralTranslator(IModel model)
        {
            var generalTranslatorExport = _generalTranslators.SingleOrDefault(x => x.Metadata.ModelType == model.GetType());

            return generalTranslatorExport != null
                       ? generalTranslatorExport.Value
                       : null;
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
                            return ResolveCustomScriptTranslator(customScriptType);
                        }
                    }
                }
            }

            //if the model is a new expression
            var newExpressionModel = model as NewExpression;

            if (newExpressionModel != null)
            {
               if ((newExpressionModel.Type.TypeKind == TypeDefinitionKind.Class ||
                   newExpressionModel.Type.TypeKind == TypeDefinitionKind.Interface ||
                   newExpressionModel.Type.TypeKind == TypeDefinitionKind.Generic) &&
                   newExpressionModel.Type is CustomScriptTypeDefinition )
               {
                   return ResolveCustomScriptTranslator((CustomScriptTypeDefinition)newExpressionModel.Type);
               }
            }

            return null;
        }

        private ITranslator ResolveCustomScriptTranslator(CustomScriptTypeDefinition customScriptType)
        {
            var customScriptTranslatorExport = _customScriptTypeTranslators.SingleOrDefault(
                x =>
                !string.IsNullOrEmpty(x.Metadata.CustomScriptType) &&
                x.Metadata.CustomScriptType == customScriptType.GetFullName());

            return customScriptTranslatorExport != null
                       ? customScriptTranslatorExport.Value
                       : null;
        }

        private readonly IEnumerable<Lazy<ITranslator, ITranslatorMetadata>> _generalTranslators;
        private readonly IEnumerable<Lazy<ITranslator, ICustomScriptTypeTranslatorMetadata>> _customScriptTypeTranslators;

    }
}
