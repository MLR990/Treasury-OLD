using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treasury.Data.Models
{
    [Table("INCOME")]
    public class Income
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("AMOUNT")]
        public double Amount { get; set; }

        [MaxLength(100)]
        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [MaxLength(150)]
        [Column("SOURCE")]
        public string Source { get; set; }

        [Column("ACCOUNTID")]
        public int AccountId { get; set; }

        [Column("TRANSACTIONDATE")]
        public DateTime TransactionDate { get; set; }
    }
}
