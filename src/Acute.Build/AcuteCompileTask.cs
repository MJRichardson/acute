using System.Linq;
using System.Reflection;
using Acute.Compiler;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Acute.Build
{
    public class AcuteCompileTask :Task
    {
        public ITaskItem[] Sources { get; set; }
        public ITaskItem[] References { get; set; }
		public string OutputAssembly { get; set; }
		public string OutputScript { get; set; }

        public override bool Execute()
        {
            //invoke the EmbedAssemblies Register method
            //this type is added to this assembly when the EmbedAssemblies.exe is run as a post-build step
			var t = typeof(AcuteCompileTask).Assembly.GetType("EmbedAssemblies.EmbeddedAssemblyLoader");
			var m = t.GetMethod("Register", BindingFlags.Static | BindingFlags.Public);
			m.Invoke(null, new object[0]);

            return Acute.Compiler.Driver.Compile(
                new CompileOptions(Sources.Select(x => x.ItemSpec), References.Select(x => x.ItemSpec), OutputAssembly, OutputScript), 
                new TaskErrorReporter(Log)
                );
        }
    }
}