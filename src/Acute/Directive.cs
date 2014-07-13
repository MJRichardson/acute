using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Acute.Angular;

namespace Acute
{
    public abstract class Directive
    {
        protected virtual string Template { get { return null; } } 
        protected virtual string TemplateUrl { get { return null; } }

        [ScriptName(DefinitionScriptName)]
        internal static object ScriptDefinition(string directiveTypeName)
        {
            var directiveType = Type.GetType(directiveTypeName);
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
            var constructorInfo = type.GetConstructors().First(); //todo: assert only one constructor
            var parameterTypes = constructorInfo.ParameterTypes;

            const int parameterNotPresentIndex = -1;

            var scopeParameterIndex =
                parameterTypes
                    .Select((x, i) => new {Index = i, ParameterType = x})
                    .Where(x => typeof(Scope).IsAssignableFrom(x.ParameterType)).Select(x => x.Index)
                    .FirstOrDefault(parameterNotPresentIndex);

            var directiveParameterIndices =
                parameterTypes
                    .Select((x, i) => new {Index = i, ParameterType = x})
                    .Where(x => typeof (Directive).IsAssignableFrom(x.ParameterType)).Select(x => x.Index)
                    .ToList();

            var functionArrayNotation = type.CreateFunctionArray();
            var parameters = functionArrayNotation.TakeExceptLast().Cast<string>().Select(x => x.Replace(".", "_")).ToList();

            functionArrayNotation =
                functionArrayNotation.ToArray().Filter((x, i, X) => scopeParameterIndex != i && !directiveParameterIndices.Contains(i));

            var injectableParameters = new List<string>();
            //get all parameters which can be injected into the directive's constructor  
            //i.e. not scope, directives, or the function itself
            for (int i = 0; i < functionArrayNotation.Count-1; i++)
            {
               if (i != scopeParameterIndex && !directiveParameterIndices.Contains(i) ) 
                   injectableParameters.Add(parameters[i]);
            }

            injectableParameters.Add(AngularServices.Compile);
            functionArrayNotation.Insert(functionArrayNotation.Count - 1, AngularServices.Compile);

            var bodyBuilder = new StringBuilder()
                .AppendLine(string.Format("var directiveDefinition = {0}.{1}('{2}');", typeof (Directive).FullName, DefinitionScriptName,
                                          type.FullName));

            if (directiveParameterIndices.Any())
            {
                bodyBuilder.AppendLine("directiveDefinition.require = [" + string.Join(",", directiveParameterIndices.Select(i => string.Format("'^{0}'", parameterTypes[i].AsAngularDirectiveName()) )) )
                           .AppendLine("];");
            }

                bodyBuilder.AppendLine("var directive;")

                .AppendLine("directiveDefinition.compile = function(){")
                .AppendLine("return {")
                .AppendLine("pre: function(scope, element, attributes, controllers) {");

                            if (scopeParameterIndex != parameterNotPresentIndex)
                            {
                                bodyBuilder.AppendLine(string.Format("var {0} = new {1}(scope);", parameters[scopeParameterIndex], typeof(Scope).FullName));
                            }

                            for (int i = 0; i < directiveParameterIndices.Count; i++ )
                            {
                                var directiveParameterIndex = directiveParameterIndices[i];
                                bodyBuilder.AppendLine(string.Format("var {0} = controllers[{1}]", parameters[directiveParameterIndex], i));
                            }

                            bodyBuilder.AppendLine(string.Format("directive = new {0}({1});", type.FullName, string.Join(",", parameters)));

                        bodyBuilder.AppendLine("},")
                        .AppendLine("post: function(scope, element ) {")
                           .AppendLine(string.Format("directive.{0}({1}, element, scope);", CompileTemplateScriptName, AngularServices.Compile ))
                        .AppendLine("}")
                    .AppendLine("}")
                .AppendLine("};" )

                .AppendLine("directiveDefinition.controller = function($scope) {")

                .AppendLine("return directive;")

                    .AppendLine("};")

                       .AppendLine("return directiveDefinition;");

            var modifiedFunc = ReflectionExtensions.CreateNewFunction(injectableParameters, bodyBuilder.ToString());
            functionArrayNotation[functionArrayNotation.Count - 1] = modifiedFunc;
            return functionArrayNotation;

        }

        [ScriptName(CompileTemplateScriptName)]
        private void CompileTemplate(Compiler compiler, dynamic element, object scope)
        {
            //todo: handle TemplateUrl
            if (!string.IsNullOrEmpty(Template))
            {
                element.html(Template);
                compiler.Compile(element.contents(), scope);
            }
        }


        internal const string DefinitionScriptName = "definition";
        private const string CompileTemplateScriptName = "compileTemplate";
    }
}