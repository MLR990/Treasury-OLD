using System;
namespace Treasury.Data.Models
{
    public class Income
    {
        public double Amount { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public int AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
