using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBank.Business
{
    public class Bank
    {

        public Bank()
        {
            Customers = new Dictionary<int, Person>();
            Accounts = new Dictionary<int, AbstractAccount>();
            LoadData();
        }

        public Teller NextTeller { get { return new Teller(); } }

        public void LoadData() 
        {
            //setup -- no datalayer yet so let's setup some default data.
            Customers.Add(1, new Person() { Id = 1, Name = "Steve Trofemuk", Address = "Here and There" });
            Customers.Add(2, new Person() { Id = 2, Name = "Bob Dole", Address = "Really out there." });

            Accounts.Add(1, new Checking(1));
            Accounts.Add(2, new Savings(2));
            Accounts.Add(3, new Savings(2));

            Accounts[1].Add(1, new AccountEntry()
            {
                Id = 1,
                Date = new DateTime(2016, 1, 1),
                Descirption = "Initial deposit",
                Credit = 300.0f,
                Debit = 0.0f
            });

            Accounts[1].Add(2, new AccountEntry()
            {
                Id = 2,
                Date = new DateTime(2016, 1, 2),
                Descirption = "Buger King",
                Credit = 0.0f,
                Debit = 7.87f
            });

            Accounts[2].Add(1, new AccountEntry()
            {
                Id = 1,
                Date = new DateTime(2016, 1, 1),
                Descirption = "Initial deposit",
                Credit = 10000.0f,
                Debit = 0.0f
            });

            Accounts[3].Add(1, new AccountEntry()
            {
                Id = 1,
                Date = new DateTime(2016, 1, 1),
                Descirption = "Initial deposit",
                Credit = 357.0f,
                Debit = 0.0f
            });
        }

        public Dictionary<int, Person> Customers { get; set; }
        public Dictionary<int, AbstractAccount> Accounts { get; set; }

    }
}
