using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PBank.Business;

namespace PBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Console.WriteLine("PBank is online!");
            Console.WriteLine("--PBank has {0:C} onhand in {1} accounts.", bank.Accounts.Sum(a => a.Value.Balance), bank.Accounts.Count());

            Console.ReadKey();
        }
    }
}
