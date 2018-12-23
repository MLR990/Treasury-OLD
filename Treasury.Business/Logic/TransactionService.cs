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
                db.Transactions.Add(new Data.Models.Transaction { Amount = model.Amount, Description = model.Description, TransactionDate = DateTime.UtcNow });
                db.SaveChanges();
            }
        }
    }
}
