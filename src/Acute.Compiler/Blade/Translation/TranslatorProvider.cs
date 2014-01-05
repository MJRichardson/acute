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
             _container = new CompositionContainer(new AggregateCatalog(
                list.Select(a => new AssemblyCatalog(a))));
        }

        /// <summary>
        /// Resolves a single import by type.
        /// </summary>
        public ITranslator ResolveTranslator(IModel model)
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
                    var methodDefinition = memberAccessExpression.Member.Definition as MethodDefinition;

                    if (methodDefinition != null)
                    {
                        var customScriptType = methodDefinition.ContainingType as CustomScriptTypeDefinition;

                        if (customScriptType != null)
                        {
                            //get translator
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

        private CompositionContainer _container;
    }
}
