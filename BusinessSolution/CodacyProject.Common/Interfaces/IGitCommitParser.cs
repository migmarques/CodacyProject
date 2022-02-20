using CodacyProject.Common.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodacyProject.Common.Interfaces
{
    public interface IGitCommitParser
    {
        List<GitCommit> Parse(string commits);
    }
}
