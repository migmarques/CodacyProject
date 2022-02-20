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
    public class GitCommandLineValidatorTests
    {
        [TestMethod]
        public void GitCommandLineValidator_ValidateEmptyUrl()
        {
            string errorMessage = string.Empty;

            try
            {
                GitCommandLineValidator.GetInstance().Validate(string.Empty);
            }catch(Exception e)
            {
                errorMessage = e.Message;
            }

            Assert.IsFalse(string.IsNullOrWhiteSpace(errorMessage), "Error message should have been thrown");
            Assert.AreEqual("Repository URL was not provided.", errorMessage, "Error message when url is empty should have been thrown");
        }

        [TestMethod]
        public void GitCommandLineValidator_ValidateNullUrl()
        {
            string errorMessage = string.Empty;

            try
            {
                GitCommandLineValidator.GetInstance().Validate(null);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }

            Assert.IsFalse(string.IsNullOrWhiteSpace(errorMessage), "Error message should have been thrown");
            Assert.AreEqual("Repository URL was not provided.", errorMessage, "Error message when url is null should have been thrown");
        }

        [TestMethod]
        public void GitCommandLineValidator_ValidateUnexistingRepository()
        {
            string errorMessage = string.Empty;

            try
            {
                GitCommandLineValidator.GetInstance().Validate("UnexistingRepo");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }

            Assert.IsFalse(string.IsNullOrWhiteSpace(errorMessage), "Error message should have been thrown");
            Assert.AreEqual("The provided repository URL does not exist.", errorMessage, "Error message when repository does not exist should have been thrown");
        }
    }
}
