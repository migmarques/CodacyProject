using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodacyProject.Common.Interfaces
{
    public interface IGitValidator
    {
        void Validate(string repositoryUrl);
    }
}
