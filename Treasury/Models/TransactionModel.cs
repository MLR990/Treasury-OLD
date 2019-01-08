using System;
using System.Collections.Generic;
using Treasury.Data.Models;

namespace Treasury.Models
{
    public class TransactionModel
    {
        public int AccountId { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
        public int VendorId { get; set; }
        public IEnumerable<Vendor> Vendors { get; set; }
    }
}
