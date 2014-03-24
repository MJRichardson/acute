using System;
using System.Linq;
using Acute.Compiler;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Acute.Build.Embed
{
    public class EmbeddedAcuteCompileTask
    {
        public static bool Execute(dynamic taskOptions, TaskLoggingHelper log)
        {
            try
            {
                return Acute.Compiler.Driver.Compile(
                    GetOptions(taskOptions),
                    new TaskErrorReporter(log)
                    );
            }
            catch (Exception ex)
            {
              log.LogErrorFromException(ex);
                return false;
            }
        }

		private static CompileOptions GetOptions(dynamic taskOptions)
		{
		    return
		        new CompileOptions(((ITaskItem[])taskOptions.Sources).Select(x => x.ItemSpec), ((ITaskItem[])taskOptions.References).Select(x => x.ItemSpec),
		                           taskOptions.OutputAssembly, taskOptions.OutputScript);
		}
    }
}