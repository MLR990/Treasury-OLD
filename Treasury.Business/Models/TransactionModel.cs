using System;
namespace Treasury.Business.Models
{
    public class TransactionModel
    {
        public double Amount { get; set; }
        public string Description { get; set; }
        public int VendorId { get; set; }
        public int CofferId { get; set; }
        public int AccountId { get; set; }
    }
}
