using System;
using System.Collections.Generic;
using System.Linq;
using Treasury.Data;

namespace Treasury.Business.Logic
{
    public class BudgetService
    {
        public BudgetService()
        {
        }
        public IEnumerable<string> GetCoffers()
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                return db.Coffers.Select(x => x.Name).ToList();
            }
        }


        public void AddCoffer(string name, string description)
        {
            using (TreasuryContext db = new TreasuryContext())
            {
                db.Coffers.Add(new Data.Models.Coffer { Name = name, Description = description });
                db.SaveChanges();
            }
        }
    }
}
