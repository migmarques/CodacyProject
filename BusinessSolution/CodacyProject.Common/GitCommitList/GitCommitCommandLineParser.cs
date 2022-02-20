using CodacyProject.Common.BusinessObjects;
using CodacyProject.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodacyProject.Common.GitCommitList
{
    public sealed class GitCommitCommandLineParser : IGitCommitParser
    {
        #region Constructors

        private GitCommitCommandLineParser() { }

        #endregion

        #region Private Properties

        private static GitCommitCommandLineParser instance;

        #endregion

        #region Public methods

        public static GitCommitCommandLineParser GetInstance()
        {
            if (instance == null)
            {
                instance = new GitCommitCommandLineParser();
            }
            return instance;
        }

        /// <summary>
        /// Picks up a string that comes from git log output and parses it into a GitCommit object
        /// </summary>
        /// <param name="commits"></param>
        /// <returns></returns>
        public List<GitCommit> Parse(string commits)
        {
            string[] splitByCommit = commits.Split(new string[] { "commit " }, StringSplitOptions.None);

            List<GitCommit> gitCommits = new List<GitCommit>();

            foreach(string commit in splitByCommit)
            {
                if(!string.IsNullOrWhiteSpace(commit))
                {
                    // FIXME: Evaluate if there is a better way to do this
                    string[] commitSplit = commit.Split('\n');
                    gitCommits.Add(new GitCommit
                    {
                        SHA = commitSplit[0],
                        Author = commitSplit[1].Split(new string[] { "Author: " }, StringSplitOptions.None)[1],
                        Date = commitSplit[2].Split(new string[] { "Date: " }, StringSplitOptions.None)[1],
                        Message = commitSplit[4]
                    });
                }
            }

            return gitCommits;
        }

        #endregion
    }
}
