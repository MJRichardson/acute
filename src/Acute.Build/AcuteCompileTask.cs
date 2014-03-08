using System.Linq;
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
            return Acute.Compiler.Driver.Compile(
                new CompileOptions(Sources.Select(x => x.ItemSpec), References.Select(x => x.ItemSpec), OutputAssembly, OutputScript), 
                new TaskErrorReporter(Log)
                );
        }
    }
}