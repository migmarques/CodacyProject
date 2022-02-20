using CodacyProject.Common.BusinessObjects;
using CodacyProject.Common.GitCommitList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodacyProject
{
    public class CodacyProjectMain
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter your repository URL:");
                string repositoryURL = Console.ReadLine();
                Console.WriteLine("Retrieving commits...");
                GitCommitListCommandLine gitCommitListCommandLine = new GitCommitListCommandLine
                {
                    RepositoryUrl = repositoryURL
                };
                List<GitCommit> gitCommits = gitCommitListCommandLine.GetCommitList();
                foreach(GitCommit gitCommit in gitCommits)
                {
                    Console.WriteLine("Commit Information:");
                    Console.WriteLine("Commit SHA: " + gitCommit.SHA);
                    Console.WriteLine("Commit Author: " + gitCommit.Author);
                    Console.WriteLine("Commit Date: " + gitCommit.Date);
                    Console.WriteLine("Commit Message: " + gitCommit.Message);
                    Console.WriteLine();
                }
            } catch(Exception e)
            {
                Console.WriteLine("The following error occured:");
                Console.WriteLine(e.Message);
            }

        }
    }
}
