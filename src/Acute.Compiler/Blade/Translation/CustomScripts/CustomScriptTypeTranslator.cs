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

             var newExpression = model as NewExpression;

             if (newExpression != null)
             {
                 TranslateNew(newExpression, context);
                 return;
             }

        }

        protected virtual void TranslateMemberInvocation(InvocationExpression model, TranslationContext context)
        {
           new InvocationExpressionTranslator().Translate(model, context); 
        }

        protected virtual void TranslateNew(NewExpression model, TranslationContext context)
        {
           new NewExpressionTranslator().Translate(model, context); 
        }
    }
}