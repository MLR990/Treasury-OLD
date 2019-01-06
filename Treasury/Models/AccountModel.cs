using System;
using System.Collections.Generic;
using Treasury.Data.Models;

namespace Treasury.Models
{
    public class AccountModel
    {
        public IEnumerable<AccountTypes> AccountTypes { get; set; }
        public string AccountType { get; set; }
        public double Balance { get; set; }
        public string Name { get; set; }
    }
}
