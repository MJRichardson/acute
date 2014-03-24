using System;
using System.IO;
using System.Reflection;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Acute.Build
{
    public class AcuteCompileTask :Task
    {
        private readonly Options _options = new Options();

        public ITaskItem[] Sources { get { return _options.Sources; } set { _options.Sources = value; } }
        public ITaskItem[] References { get { return _options.References; } set { _options.References = value; } }
		public string OutputAssembly { get { return _options.OutputAssembly; } set { _options.OutputAssembly = value; } }
		public string OutputScript { get { return _options.OutputScript; } set { _options.OutputScript = value; } }

        public override bool Execute()
        {
			var setup = new AppDomainSetup { ApplicationBase = Path.GetDirectoryName(typeof(AcuteCompileTask).Assembly.Location) };
			var appDomain = AppDomain.CreateDomain("Acute.Build", null, setup);
			var executor = (Executor)appDomain.CreateInstanceAndUnwrap(typeof(Executor).Assembly.FullName, typeof(Executor).FullName);
			return executor.Execute(_options,  Log);
        }

        [Serializable]
        public class Options
        {
            public ITaskItem[] Sources { get; set; }
            public ITaskItem[] References { get; set; }
    		public string OutputAssembly { get; set; }
    		public string OutputScript { get; set; }
        }

        private class Executor : MarshalByRefObject
        {
			public bool Execute(Options options, TaskLoggingHelper log) {

                //invoke the EmbedAssemblies Register method
                //this type is added to this assembly when the EmbedAssemblies.exe is run as a post-build step
				var t = typeof(AcuteCompileTask).Assembly.GetType("EmbedAssemblies.EmbeddedAssemblyLoader");
				var m = t.GetMethod("Register", BindingFlags.Static | BindingFlags.Public);
				m.Invoke(null, new object[0]);

				var embeddedAssembly = Assembly.Load("Acute.Build.Embed");
				var embeddedTask = embeddedAssembly.GetType("Acute.Build.Embed.EmbeddedAcuteCompileTask");
				return (bool)embeddedTask.GetMethod("Execute").Invoke(null, new object[] { options, log });
			}
        }
    }
}