using CodacyProject.Common.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodacyProject.Common.Interfaces
{
    /// <summary>
    /// Interface that defines necessary implementations for a provider of a git repository commit list
    /// </summary>
    public interface IGitCommitListProvider
    {
        List<GitCommit> GetCommitList();
    }
}
