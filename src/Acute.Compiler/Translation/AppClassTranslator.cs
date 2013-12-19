using System.IO;
using System.Linq;
using Acute.Compiler.Core;
using Acute.Compiler.JavascriptTemplates;
using Blade.Compiler;
using Blade.Compiler.Models;
using Blade.Compiler.Translation;

namespace Acute.Compiler.Translation
{
    internal class AppClassTranslator : ClassTranslator
    {
        public override void Translate(Blade.Compiler.Models.ClassDeclaration model, TranslationContext context)
        {
            //the constructor will be translated into the body of the module.config() method

            //get the class constructor
            var instanceCtors = model.Constructors.Where(c => !c.IsStatic);
            if (instanceCtors.Count() > 1)
                throw new CompilationException("Constructor overloading is not supported.", model.Constructors[1]);

            var ctor = instanceCtors.FirstOrDefault() ?? new ConstructorDeclaration();


            //todo: write initialization of class fields
            //todo: handle case where app is a derived class

            //we need to write the constructor body, but not to the real output-stream. We want to pass it as a parameter to
            //the module template
            string ctorBody = null;
            //so we switch out the current output stream
            var realOutputStream = context.OutputStream;

            //and replace it with a temporary stream
            using (var tempStream = new MemoryStream())
            {
                context.OutputStream = tempStream;

                //write the constructor body to the temp stream
                context.WriteModelBody(ctor.Body);
                tempStream.Position = 0;
                using (var reader = new StreamReader(tempStream))
                {
                    //and capture it as a string
                    ctorBody = reader.ReadToEnd();
                }
            }

            context.OutputStream = realOutputStream;
            //write the module template 
            context.Write(new module(model.Definition.GetFullName() + "Module", ctorBody, ctor.Parameters.Select(p => p.Definition.Type.GetFullName()).ToArray()  ).TransformText());


            //and write the standard blade transformation of the class
            base.Translate(model, context);
        }
    }
}