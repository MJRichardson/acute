using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

﻿namespace Acute
{
    public abstract class Directive
    {
        public virtual string Template { get { return null; } } 
        public virtual string TemplateUrl { get { return null; } }



        [ScriptName(DefinitionScriptName)]
        internal object ScriptDefinition()
        {
            var definition = new JsDictionary();

            if (Template != null)
                definition["template"] = Template;
            else if (TemplateUrl != null)
                definition["templateUrl"] = TemplateUrl;

            var scope = new JsDictionary();

            foreach (
                var domAttributeBinding in
                    this.GetType().GetCustomAttributes(typeof (BindDomAttributeToDirectiveScopeAttribute), false).Map(x => (BindDomAttributeToDirectiveScopeAttribute)x))
            {
                string angularBindingMagicPrefix;

                switch (domAttributeBinding.BindingType)
                {
                    case DomAttributeBindingType.Bound:
                        angularBindingMagicPrefix = "=";
                        break;

                    case DomAttributeBindingType.Evaluated:
                        angularBindingMagicPrefix = "@"; 
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                scope[domAttributeBinding.PropertyName] = angularBindingMagicPrefix + domAttributeBinding.AttributeName;
            }

            definition["scope"] = scope;

            return definition;

        }

        internal static IList<object> BuildDirectiveFunction(Type type)
        {
            var functionArrayNotation = type.CreateFunctionArray();
            var parameters = functionArrayNotation.TakeExceptLast().Cast<string>().Select(x => x.Replace(".", "_")).ToList();

            string body = String.Format("var directive = new {0}({1});\n", type.FullName, string.Join(",", parameters));
            body += string.Format("return directive.{0}();", DefinitionScriptName);

            var modifiedFunc = ReflectionExtensions.CreateNewFunction(parameters,body);
            functionArrayNotation[parameters.Count] = modifiedFunc;
            return functionArrayNotation;
        }

        internal const string DefinitionScriptName = "definition";
    }
}