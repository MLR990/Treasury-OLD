using System;
using System.Collections.Generic;
using Treasury.Data.Models;

namespace Treasury.Models
{
    public class BudgetModel
    {
        public int ExpenseId { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
    }
}
