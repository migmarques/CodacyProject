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
    public class GitCommitListGitHubAPITests
    {
        [TestMethod]
        public void GetCommitList_HappyPath()
        {
            GitCommitListGitHubAPI gitCommitListGitHubAPI = new GitCommitListGitHubAPI
            {
                RepositoryUrl = "https://github.com/migmarques/CodacyProject/"
            };
            List<GitCommit> gitCommits = gitCommitListGitHubAPI.GetCommitList();
            Assert.IsTrue(gitCommits.Any(), "Commits were already made so the list of commits must have content");
            Assert.IsTrue(gitCommits.Any(x => x.Message.Contains("Initial commit")), "At least first commit must be included");
        }
    }
}
