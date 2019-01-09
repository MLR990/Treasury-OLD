using System;
using Treasury.Business.Models;
using Treasury.Data;

namespace Treasury.Business.Logic
{
    public class TransactionService
    {
        public TransactionService()
        {
        }

        public void AddTransaction(TransactionModel model)
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                db.Transactions.Add(new Data.Models.Transaction { Amount = model.Amount, Description = model.Description, VendorId = model.VendorId, TransactionDate = DateTime.UtcNow });
                db.SaveChanges();
            }
        }

        public void AddIncome(double amount, string description, string source, int accountId)
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                db.Income.Add(new Data.Models.Income { Amount = amount, Description = description, AccountId = accountId, TransactionDate = DateTime.UtcNow, Source = source });
                db.SaveChanges();
            }
        }



    }
}
