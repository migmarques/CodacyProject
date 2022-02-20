using CodacyProject.Common.BusinessObjects;
using CodacyProject.Common.Interfaces;
using CodacyProject.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodacyProject.Common.GitCommitList
{
    public class GitCommitListCommandLine : IGitCommitListProvider
    {
        public string RepositoryUrl { get; set; }

        public List<GitCommit> GetCommitList()
        {
            GitCommandLineValidator.GetInstance().Validate(RepositoryUrl);

            if(!GitCommandLineValidator.GetInstance().IsCheckedOut(RepositoryUrl))
            {
                CheckOutRepository();
            }

            // FIXME: If possible turn the command into a constant
            string output = CommandLineExecutor.RunCommand("git log");

            return GitCommitCommandLineParser.GetInstance().Parse(output);
        }

        private void CheckOutRepository()
        {
            CommandLineExecutor.RunCommand("git remote set-url origin " + RepositoryUrl);
            CommandLineExecutor.RunCommand("git checkout");
        }
    }
}
