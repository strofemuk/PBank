using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBank.Business
{
    public class AccountEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Descirption { get; set; }
        public float Debit { get; set; }
        public float Credit { get; set; }
    }
}
