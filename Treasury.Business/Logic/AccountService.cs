using System;
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
