using System.Collections.Generic;
using Blade.Compiler.Models;
using Roslyn.Compilers.CSharp;

namespace Blade.Compiler.Transformation.CSharp
{
  internal partial class Transformer: SyntaxVisitor<IEnumerable<IModel>>
  {
        public override IEnumerable<IModel> VisitTypeOfExpression(TypeOfExpressionSyntax node)
        {
            var model = Create<TypeOfExpression>(node);
            model.Target = GetDefinition<ITypeDefinition>(node.Type); 
            yield return model;
        } 
  }
}