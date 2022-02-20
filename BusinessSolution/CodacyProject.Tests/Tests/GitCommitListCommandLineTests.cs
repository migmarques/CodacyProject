using CodacyProject.Common.BusinessObjects;
using CodacyProject.Common.GitCommitList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodacyProject.Tests
{
    [TestClass]
    public class GitCommitListCommandLineTests
    {
        [TestMethod]
        public void GetCommitList_HappyPath()
        {
            GitCommitListCommandLine gitCommitListCommandLine = new GitCommitListCommandLine
            {
                RepositoryUrl = "https://github.com/migmarques/CodacyProject/"
            };
            List<GitCommit> gitCommits = gitCommitListCommandLine.GetCommitList();
            Assert.IsTrue(gitCommits.Any(), "Commits were already made so the list of commits must have content");
            Assert.IsTrue(gitCommits.Any(x => x.Message.Contains("Initial commit")), "First commit must be included");
        }
    }
}
