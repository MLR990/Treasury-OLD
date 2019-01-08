using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treasury.Data.Models
{
    [Table("TRANSACTION")]
    public class Transaction
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("AMOUNT")]
        public double Amount { get; set; }

        [Column("DESCRIPTION")]
        [MaxLength(100)]
        public string Description { get; set; }

        [Column("TRANSACTIONDATE")]
        public DateTime TransactionDate { get; set; }

        [Column("VENDORID")]
        public int VendorId { get; set; }

    }
}
