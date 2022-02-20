using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodacyProject.Common.BusinessObjects
{
    /// <summary>
    /// Class that represents a Git commit with necessary information
    /// </summary>
    public class GitCommit
    {
        public string SHA { get; set; }

        public string Message { get; set; }

        // Ideally this should be a DateTime but for a first version I'll simplify
        public string Date { get; set; }

        public string Author { get; set; }
    }
}