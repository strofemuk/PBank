using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBank.Business
{
    public class Teller
    {
        public Result Withdraw(float amount, AbstractAccount account)
        {
            Result result = new Result() { Success = false, Information = "Withrdraw was not successful" };
            try
            {
                if (account.CanWithdraw(amount))
                {
                    AccountEntry entry = new AccountEntry()
                    {
                        Id = account.NextId,
                        Date = DateTime.Now.Date,
                        Descirption = "Counter withdrawal",
                        Debit = amount
                    };
                    account.Add(entry.Id, entry);
                    result.Information = "Withdwaw was successful.";
                    result.Success = account.ContainsValue(entry);
                }
                else
                {
                    result.Information = "Insufficient funds.";
                    result.Success = false;
                }
            }
            catch (ApplicationException exception)
            {
                result.Success = false;
                result.Information = exception.Message;
                result.Exception = exception;
            }
            return result;
        }

        public Result Deposit(float amount, AbstractAccount account)
        {
            Result result = new Result() { Success = false, Information = "Deposit was not successful" };
            try
            {
                if (account.CanDeposit(amount))
                {
                    AccountEntry entry = new AccountEntry()
                    {
                        Id = account.NextId,
                        Date = DateTime.Now.Date,
                        Descirption = "Counter withdrawal",
                        Credit = amount
                    };
                    account.Add(entry.Id, entry);
                    result.Information = "Deposit was successful.";
                    result.Success = account.ContainsValue(entry);
                } else
                {
                    result.Information = "Cannot process deposit.";
                    result.Success = false;
                }
            }
            catch (ApplicationException exception)
            {
                result.Success = false;
                result.Information = exception.Message;
                result.Exception = exception;
            }
            return result;
        }

        public Result Close(AbstractAccount account)
        {
            Result result = new Result() { Success = false, Information = "Attemt to close the account was unsuccessful." };
            try
            {
                if (account.CanClose())
                {
                    account.IsClosed = true;
                    result.Success = true;
                    result.Information = "Account is closed.";
                }
                else
                {
                    result.Information = "Account has a balance.";            
                }
            }
            catch (ApplicationException exception)
            {
                result.Success = false;
                result.Information = exception.Message;
                result.Exception = exception;
            }

            return result;

        }
    }
}
