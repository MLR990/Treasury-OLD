using System;
using System.Collections.Generic;
using System.Linq;
using Treasury.Data;
using Treasury.Data.Models;

namespace Treasury.Business.Logic
{
    public class AccountService
    {
        public void AddAccount(string name, string type, double balance)
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                db.Accounts.Add(new Data.Models.Account { Name = name, Balance = balance, Type = GetType(type) });
                db.SaveChanges();
            }
        }
        public IEnumerable<Account> GetAccounts()
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                return db.Accounts.Select(x => x).ToList();
            }
        }

        public void UpdateAccountBalance(int accountId, double amount)
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                var account = db.Accounts.Where(a => a.Id == accountId).FirstOrDefault();
                if (account != null)
                {
                    account.Balance = account.Balance - amount;
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<Account> GetAccountsForTransactions()
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                return db.Accounts.Where(x => x.Type == AccountTypes.Cash || x.Type == AccountTypes.Checking || x.Type == AccountTypes.Credit).Select(x => x).ToList();
            }
        }




        private AccountTypes GetType(string type)
        {
            switch (type)
            {
                case "Checking":
                    return AccountTypes.Checking;
                case "Savings":
                    return AccountTypes.Savings;
                case "Credit":
                    return AccountTypes.Credit;
                case "Cash":
                    return AccountTypes.Cash;
                default:
                    return AccountTypes.Investment;
            }
        }
    }
}
