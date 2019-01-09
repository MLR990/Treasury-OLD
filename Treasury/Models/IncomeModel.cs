using System;
using System.Collections.Generic;
using Treasury.Data.Models;

namespace Treasury.Models
{
    public class IncomeModel
    {
        public int AccountId { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}
