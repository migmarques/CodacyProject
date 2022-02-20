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
            if (pageSize > 0 && pageNumber > 0)
            {
                gitCommits = gitCommits.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            }

            return gitCommits;
        }
    }
}
