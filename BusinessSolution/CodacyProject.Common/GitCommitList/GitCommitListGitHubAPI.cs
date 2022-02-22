using CodacyProject.Common.BusinessObjects;
using CodacyProject.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace CodacyProject.Common.GitCommitList
{
    public class GitCommitListGitHubAPI : IGitCommitListProvider
    {
        public string RepositoryUrl { get; set; }
        public List<GitCommit> GetCommitList()
        {
            string ownerAndRepo = RepositoryUrl.Split(new string[] { "github.com/" }, StringSplitOptions.None)[1];
            if(!ownerAndRepo.EndsWith("/"))
            {
                ownerAndRepo += "/";
            }
            string api = "https://api.github.com/repos/" + ownerAndRepo + "commits";

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("User-Agent", "request");
                string result = client.DownloadString(api);

                return GitCommitListGitHubAPIParser.GetInstance().Parse(result);
            }
            
        }
    }
}
