using CodacyProject.Common.BusinessObjects;
using CodacyProject.Common.Interfaces;
using CodacyProject.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodacyProject.Common.GitCommitList
{
    public class GitCommitListCommandLine : IGitCommitListProvider
    {
        public string RepositoryUrl { get; set; }

        private string ClonedFolderPath { get; set; }

        public List<GitCommit> GetCommitList()
        {
            GitCommandLineValidator.GetInstance().Validate(RepositoryUrl);

            Clone();

            // FIXME: If possible turn the command into a constant
            string output = CommandLineExecutor.RunCommand("git log", workingDirectory: ClonedFolderPath);

            FileDirectoryUtilities.DeleteFolder(ClonedFolderPath);

            return GitCommitCommandLineParser.GetInstance().Parse(output);
        }

        private void Clone()
        {
            // This could be enhanced to require input from the user
            ClonedFolderPath = "C:/repository";
            CommandLineExecutor.RunCommand("mkdir repository");
            string output = CommandLineExecutor.RunCommand("git clone " + RepositoryUrl + " " + "repository");
            if (output.Contains("error"))
            {
                FileDirectoryUtilities.DeleteFolder(ClonedFolderPath);
                throw new Exception("Clone of repository " + RepositoryUrl + " failed.");
            }
        }
    }
}
