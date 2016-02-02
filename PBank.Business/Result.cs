using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBank.Business
{
    public struct Result
    {
        public bool Success { get; set; }
        public string Information { get; set; }
        public Exception Exception { get; set; }
    }
}
