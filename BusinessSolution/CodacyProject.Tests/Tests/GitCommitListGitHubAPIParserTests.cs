using CodacyProject.Common.BusinessObjects;
using CodacyProject.Common.GitCommitList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodacyProject.Tests
{
    [TestClass]
    public class GitCommitListGitHubAPIParserTests
    {
        [TestMethod]
        public void GitCommitCommandLineParser_HappyPath()
        {
            string commit;
            using (StreamReader r = new StreamReader("Tests/commitsMock.json"))
            {
                commit = r.ReadToEnd();
            }
            List<GitCommit> gitCommits = GitCommitListGitHubAPIParser.GetInstance().Parse(commit);

            Assert.IsTrue(gitCommits.Any(), "Commits must have been parsed");
            Assert.AreEqual("a57a22960332040d500ee80eb4457e38cb9665df", gitCommits[0].SHA, "SHA must be the same as the commit");
            Assert.IsTrue(gitCommits[0].Author.Contains("mpamarques"), "Author must be the same as the commit");
            Assert.IsTrue(gitCommits[0].Date.Contains("02/21/2022 20:26:08"), "Date must be the same as the commit");
            Assert.AreEqual("fix: Refactor to properly clone entered repository by the user", gitCommits[0].Message, "Message must be the same as the commit");
        }
    }
}
