using CodacyProject.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CodacyProject.Tests
{
    [TestClass]
    public class CommandLineExecutorTests
    {
        [TestCleanup]
        public void TestCleanUp()
        {
            if(Directory.Exists("TestFolder"))
            {
                Directory.Delete("TestFolder");
            }
        }

        [TestMethod]
        public void CommandLineExecutor_RunCommand()
        {
            try
            {
                CommandLineExecutor.RunCommand("mkdir TestFolder");
            } catch(Exception e)
            {
                Assert.Fail("Unexpected error occured: " + e.Message);
            }

            Assert.IsTrue(Directory.Exists("TestFolder"), "TestFolder must have been created");
        }

        [TestMethod]
        public void CommandLineExecutor_RunInvalidCommand()
        {
            string errorMessage = string.Empty;
            try
            {
                CommandLineExecutor.RunCommand("invalidCommand");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                Assert.Fail("Unexpected error occured: " + errorMessage);
            }

            Assert.IsTrue(string.IsNullOrEmpty(errorMessage), "CommandLineExecutor should not throw any error if command is invalid, just the error message of the command should be presented");
        }
    }
}
