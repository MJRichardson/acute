using System;
using System.Collections.Generic;
using System.Linq;
using Acute.Angular;

namespace Acute
{
    public abstract class Controller
    {

        internal static IList<object> BuildControllerFunction(Type type)
        {
            var constructorInfo = type.GetConstructors().First(); //todo: assert only one constructor
            var parameterTypes = constructorInfo.ParameterTypes;

            const int parameterNotPresentIndex = -1;

            var scopeParameterIndex =
                parameterTypes
                    .Select((x, i) => new {Index = i, ParameterType = x})
                    .Where(x => typeof(Scope).IsAssignableFrom(x.ParameterType)).Select(x => x.Index)
                    .FirstOrDefault(parameterNotPresentIndex);

            var functionArrayNotation = type.CreateFunctionArray();
            var parameters = functionArrayNotation.TakeExceptLast().Cast<string>().Select(x => x.Replace(".", "_")).ToList();

            string body = ""; 
            if (scopeParameterIndex != parameterNotPresentIndex )
                body += string.Format("var {0} = new {1}({2});" , parameters[scopeParameterIndex], typeof(Acute.Scope).FullName, AngularServices.Scope);

            body += String.Format("var controller = new {0}({1});\n", type.FullName, string.Join(",", parameters));

            if (scopeParameterIndex != parameterNotPresentIndex)
            {
                functionArrayNotation[scopeParameterIndex] = AngularServices.Scope;
                parameters[scopeParameterIndex] = AngularServices.Scope;
            }

            var modifiedFunc = ReflectionExtensions.CreateNewFunction(parameters,body);
            functionArrayNotation[parameters.Count] = modifiedFunc;

            return functionArrayNotation;
        }
    }
}