using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

﻿namespace Acute
{
    public abstract class Directive
    {
        protected virtual string Template { get { return null; } } 
        protected virtual string TemplateUrl { get { return null; } }



        [ScriptName(DefinitionScriptName)]
        internal static object ScriptDefinition(Type directiveType)
        {
            var definition = new JsDictionary();

            //if (Template != null)
            //    definition["template"] = Template;
            //else if (TemplateUrl != null)
            //    definition["templateUrl"] = TemplateUrl;

            var scope = new JsDictionary();

            foreach (
                var domAttributeBinding in
                    directiveType.GetCustomAttributes(typeof (BindDomAttributeToDirectiveScopeAttribute), false).Map(x => (BindDomAttributeToDirectiveScopeAttribute)x))
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

            string restrict = "";
            var domTypeAttribute = directiveType.GetCustomAttributes(typeof (DirectiveDomTypesAttribute), false).Cast<DirectiveDomTypesAttribute>().FirstOrDefault();

            if (domTypeAttribute != null)
            {
                if ((DirectiveDomTypes.Attribute & domTypeAttribute.DomTypes) != 0)
                    restrict += "A";

                if ((DirectiveDomTypes.Element & domTypeAttribute.DomTypes) != 0)
                    restrict += "E";

                if ((DirectiveDomTypes.Class & domTypeAttribute.DomTypes) != 0)
                    restrict += "C";
            }

            definition["restrict"] = restrict;


            return definition;

        }

        internal static IList<object> BuildDirectiveFunction(Type type)
        {
            var constructorInfo = type.GetConstructors()[0]; //todo: assert only one constructor
            var parameterTypes = constructorInfo.ParameterTypes;

            const int parameterNotPresentIndex = -1;

            var scopeParameterIndex =
                parameterTypes
                    .Select((x, i) => new {Index = i, ParameterType = x})
                    .Where(x => x.ParameterType.IsInstanceOfType(typeof(IScope))).Select(x => x.Index)
                    .FirstOrDefault(parameterNotPresentIndex);

            var functionArrayNotation = type.CreateFunctionArray();

            var nonScopeParameters = new List<Object>();
            //get all parameters except the scope parameter (if there is one) and the last (which is the function itself)
            for (int i = 0; i < functionArrayNotation.Count; i++)
            {
               if (i != scopeParameterIndex && i != functionArrayNotation.Count -1) 
                   nonScopeParameters.Add(((string)functionArrayNotation[i]).Replace(".", "_"));
            }

            //var functionArrayNotation = type.CreateFunctionArray();
            //var parameters = functionArrayNotation.TakeExceptLast().Cast<string>().Select(x => x.Replace(".", "_")).ToList();

            //string body = String.Format("var directive = new {0}({1});\n", type.FullName, string.Join(",", parameters));
            //body += string.Format("return directive.{0}();", DefinitionScriptName);

            //var modifiedFunc = ReflectionExtensions.CreateNewFunction(parameters,body);
            //functionArrayNotation[parameters.Count] = modifiedFunc;
            //return functionArrayNotation;
        }

        internal const string DefinitionScriptName = "definition";
    }
}