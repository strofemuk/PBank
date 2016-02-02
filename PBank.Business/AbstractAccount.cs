using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBank.Business
{
    public abstract class AbstractAccount : Dictionary<int, AccountEntry>
    {
        public AbstractAccount(int ownerId) :this() {
            OwnerId = ownerId;
        }

        private AbstractAccount()
        {
            IsClosed = false;
        }

        public abstract Byte AccountType { get; }

        public virtual bool CanDeposit(float amount)
        {
            return !IsClosed;
        }

        public virtual bool CanWithdraw(float amount)
        {
            return ((this.Balance >= amount) && (!IsClosed));
        }

        public virtual bool CanClose()
        {
            return ((this.Balance == 0.0F) && (!IsClosed));
        }

        public int NextId
        {
            get { return this.Max(l => l.Value.Id) + 1; }
        }

        public float Balance
        {
            get
            {
                float credit = this.Sum(l => l.Value.Credit);
                float debit = this.Sum(l => l.Value.Debit);
                return credit - debit;
            }
        }

        public bool IsClosed { get; set; }

        public int OwnerId { get; private set; }
    }
}
