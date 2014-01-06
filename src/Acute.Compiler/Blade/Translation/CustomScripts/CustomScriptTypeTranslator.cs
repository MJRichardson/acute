using System;
using System.Collections.Generic;
using Blade.Compiler.Models;

namespace Blade.Compiler.Translation.CustomScripts
{
    internal abstract class CustomScriptTypeTranslator : ITranslator
    {
        // explicit interface implementation
         void ITranslator.Translate(IModel model, TranslationContext context)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var invocationExpression = model as InvocationExpression;

            if (invocationExpression != null)
            {
                TranslateMemberInvocation(invocationExpression, context);
                return;
            }

        }

        protected abstract void TranslateMemberInvocation(InvocationExpression model,TranslationContext context);
    }
}