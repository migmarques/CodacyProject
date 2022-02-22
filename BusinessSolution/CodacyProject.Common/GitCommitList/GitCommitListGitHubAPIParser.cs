using CodacyProject.Common.BusinessObjects;
using CodacyProject.Common.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodacyProject.Common.GitCommitList
{
    public sealed class GitCommitListGitHubAPIParser : IGitCommitParser
    {
        #region Constructors

        private GitCommitListGitHubAPIParser() { }

        #endregion

        #region Private Properties

        private static GitCommitListGitHubAPIParser instance;

        #endregion

        #region Public methods

        public static GitCommitListGitHubAPIParser GetInstance()
        {
            if (instance == null)
            {
                instance = new GitCommitListGitHubAPIParser();
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
            List<GitCommit> gitCommits = new List<GitCommit>();

            dynamic dynJson = JsonConvert.DeserializeObject(commits);
            foreach (var item in dynJson)
            {
                gitCommits.Add(new GitCommit
                {
                    SHA = item.sha,
                    Author = item.commit.author.name,
                    Date = item.commit.author.date,
                    Message = item.commit.message
                });
            }

            return gitCommits;
        }

        #endregion
    }
}
