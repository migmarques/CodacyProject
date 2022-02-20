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
    public class GitCommitCommandLineParserTests
    {
        [TestMethod]
        public void GitCommitCommandLineParser_HappyPath()
        {
            string commit = "commit b51312d87cc08796d7c8464fcd354cbda5291299\nAuthor: migmarques < 100039645 + migmarques@users.noreply.github.com >\nDate:   Sat Feb 19 17:07:34 2022 + 0000\n\nInitial commit\n";

            List<GitCommit> gitCommits = GitCommitCommandLineParser.GetInstance().Parse(commit);

            Assert.IsTrue(gitCommits.Any(), "One commit must have been parsed");
            Assert.AreEqual(1, gitCommits.Count, "One commit must have been parsed, but more than one were");
            Assert.AreEqual("b51312d87cc08796d7c8464fcd354cbda5291299", gitCommits[0].SHA, "SHA must be the same as the commit");
            Assert.IsTrue(gitCommits[0].Author.Contains("migmarques"), "Author must be the same as the commit");
            Assert.IsTrue(gitCommits[0].Date.Contains("Feb 19 17:07:34"), "Date must be the same as the commit");
            Assert.AreEqual("Initial commit", gitCommits[0].Message, "Message must be the same as the commit");
        }
    }
}
