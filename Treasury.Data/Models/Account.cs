using System;
namespace Treasury.Data.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public double Balance { get; set; }
        public AccountTypes AccountType { get; set; }

    }

    public enum AccountTypes
    {
        Checking,
        Savings,
        Credit,
        Cash
    }
}
