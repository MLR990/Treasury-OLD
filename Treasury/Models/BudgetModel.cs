using System;
using System.Collections.Generic;
using Treasury.Data.Models;

namespace Treasury.Models
{
    public class BudgetModel
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public int Order { get; set; }
        public bool Necessary { get; set; }
        public IEnumerable<BudgetType> Types { get; set; }
        public IEnumerable<Month> Months { get; set; }
        public int CofferId { get; set; }
        public IEnumerable<MonthlyCoffer> Coffers { get; set; }
        public IEnumerable<Vendor> Vendors { get; set; }
    }
}
