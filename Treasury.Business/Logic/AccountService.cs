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
