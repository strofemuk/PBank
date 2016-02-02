using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBank.Business
{
    public class Checking : AbstractAccount
    {
        public Checking(int ownerId) : base(ownerId)
        {
            
        }

        public override byte AccountType
        {
            get
            {
                return 1;
            }
        }
    }
}
