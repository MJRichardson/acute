﻿using System;
using System.Collections.Generic;
using System.Linq;
using Blade.Compiler.Models;

namespace Blade.Compiler.Translation
{
    /// <summary>
    /// Handles translation of an invocation expression.
    /// </summary>
    [Translator]
    internal class InvocationExpressionTranslator : Translator<InvocationExpression>
    {
        public override void Translate(InvocationExpression model, TranslationContext context)
        {
            context.WriteModel(model.Expression);
            var args = TranslationHelper.GetInvocationArgs(model);

            // when invoking explicitly, use 'call' and 
            // explicity pass the 'this' context in
            if (context.UsingExplicitCall)
            {
                // use an explicit invocation call
                var hasArgs = args.Any() || context.ExtensionMethodTarget != null;
                context.Write(".call(this" + (hasArgs ? ", " : ""));

                // reset explicit call flag
                context.UsingExplicitCall = false;
            }
            else context.Write("(");

            // handle extension methods
            if (context.ExtensionMethodTarget != null)
            {
                // capture and set target to null, otherwise another
                // invocation expression will result in an infinite loop
                var target = context.ExtensionMethodTarget;
                context.ExtensionMethodTarget = null;

                context.WriteModel(target);
                if (args.Any())
                    context.Write(", ");
            }

            context.WriteModels(args, ", ");
            context.Write(")");
        }

    }
}
