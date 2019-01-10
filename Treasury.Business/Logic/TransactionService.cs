using System;
using Treasury.Business.Models;
using Treasury.Data;
using System.Linq;

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
                db.Transactions.Add(new Data.Models.Transaction { Amount = model.Amount, Description = model.Description, VendorId = model.VendorId, TransactionDate = DateTime.UtcNow, CofferId = model.CofferId, AccountId = model.AccountId });
                db.SaveChanges();
            }
        }


        public void ApplySpendingToCoffer(int cofferId, double amount)
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                var coffer = db.Coffers.Where(x => x.Id == cofferId).FirstOrDefault();
                if (coffer != null)
                {
                    coffer.AmountSpent = coffer.AmountSpent + amount;
                    db.SaveChanges();
                }
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
