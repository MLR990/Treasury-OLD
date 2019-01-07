using System;
using System.Collections.Generic;
using Treasury.Data.Models;

namespace Treasury.Models
{
    public class CofferModel
    {
        public int BudgetId { get; set; }
        public IEnumerable<Expense> Budgets { get; set; }
    }
}
