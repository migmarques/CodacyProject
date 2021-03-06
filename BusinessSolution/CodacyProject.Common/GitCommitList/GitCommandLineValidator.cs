using CodacyProject.Common.Interfaces;
using CodacyProject.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodacyProject.Common.GitCommitList
{
    public sealed class GitCommandLineValidator : IGitValidator
    {
        #region Constructors

        private GitCommandLineValidator() { }

        #endregion

        #region Private Properties

        private static GitCommandLineValidator instance;

        #endregion

        #region Public methods

        public static GitCommandLineValidator GetInstance()
        {
            if (instance == null)
            {
                instance = new GitCommandLineValidator();
            }
            return instance;
        }

        /// <summary>
        /// Validates if URL is empty and if it exists
        /// </summary>
        /// <param name="repositoryUrl"></param>
        public void Validate(string repositoryUrl)
        {
            if(string.IsNullOrWhiteSpace(repositoryUrl))
            {
                throw new Exception("Repository URL was not provided.");
            }

            // FIXME: If possible turn the command into a constant
            string output = CommandLineExecutor.RunCommand("git ls-remote " + repositoryUrl);

            if (output.Contains("error"))
            {
                throw new Exception("Repository URL validation failed.");
            }
        }

        #endregion
    }
}
