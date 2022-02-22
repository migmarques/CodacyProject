using CodacyProject.Common.BusinessObjects;
using CodacyProject.Common.GitCommitList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodacyProject.Facades
{
    public static class CodacyProjectFacade
    {
        public static List<GitCommit> GetCommitListByCommandLine(string repositoryURL, int pageSize, int pageNumber)
        {
            GitCommitListCommandLine gitCommitListCommandLine = new GitCommitListCommandLine
            {
                RepositoryUrl = repositoryURL
            };
            List<GitCommit> gitCommits = gitCommitListCommandLine.GetCommitList();
            return GetPageGitCommits(gitCommits, pageSize, pageNumber);
        }

        public static List<GitCommit> GetCommitListByGitHubAPI(string repositoryURL, int pageSize, int pageNumber)
        {
            GitCommitListGitHubAPI gitCommitListGitHubAPI = new GitCommitListGitHubAPI
            {
                RepositoryUrl = repositoryURL
            };
            List<GitCommit> gitCommits = gitCommitListGitHubAPI.GetCommitList();
            return GetPageGitCommits(gitCommits, pageSize, pageNumber);
        }

        private static List<GitCommit> GetPageGitCommits(List<GitCommit> gitCommits, int pageSize, int pageNumber)
        {
            List<GitCommit> gitCommitsToReturn = new List<GitCommit>(gitCommits);
            if (pageSize > 0 && pageNumber > 0)
            {
                gitCommitsToReturn = gitCommits.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            }

            return gitCommitsToReturn;
        }
    }
}
