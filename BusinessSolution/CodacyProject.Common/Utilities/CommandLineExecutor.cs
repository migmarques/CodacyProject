using CodacyProject.Common.Constants;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodacyProject.Common.Utilities
{
    public static class CommandLineExecutor
    {
        /// <summary>
        /// Runs any command on the command line and returns the output
        /// </summary>
        /// <param name="command">Full command with arguments to execute</param>
        /// <param name="hideWindow">If the cmd line should be hidden</param>
        /// <returns></returns>
        public static string RunCommand(string command, bool hideWindow = true)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            if(hideWindow)
            {
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            }
            startInfo.FileName = GeneralConstants.CommandLineExe;
            // The /C is mandatory to run a command
            startInfo.Arguments = "/C" + command;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }
    }
}
