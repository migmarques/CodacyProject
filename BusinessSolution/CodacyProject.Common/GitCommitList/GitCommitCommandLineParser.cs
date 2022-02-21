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
            string[] splitByCommit = commits.Split(new string[] { "commit " }, StringSplitOptions.RemoveEmptyEntries);

            List<GitCommit> gitCommits = new List<GitCommit>();

            foreach (string commit in splitByCommit)
            {
                // FIXME: Evaluate if there is a better way to do this
                string[] commitSplit = commit.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                string message = string.Empty;
                string author = string.Empty;
                string date = string.Empty;
                int indexToUse = 1;
                if(commit.Contains("Author:"))
                {
                    indexToUse++;
                    author = commitSplit.FirstOrDefault(x => x.Contains("Author:")).Split(new string[] { "Author: " }, StringSplitOptions.None)[1];
                }
                if(commit.Contains("Date:"))
                {
                    indexToUse++;
                    date = commitSplit.FirstOrDefault(x => x.Contains("Date:")).Split(new string[] { "Date: " }, StringSplitOptions.None)[1];
                }
                if(commit.Contains("Merge"))
                {
                    indexToUse++;
                }
                for (int index = indexToUse; index < commitSplit.Length; index++)
                {
                    message += commitSplit[index];
                    if(index < commitSplit.Length - 1)
                    {
                        message += Environment.NewLine;
                    }
                }
                gitCommits.Add(new GitCommit
                {
                    SHA = commitSplit[0],
                    Author = author,
                    Date = date,
                    Message = message
                });
            }

            return gitCommits;
        }

        #endregion
    }
}
