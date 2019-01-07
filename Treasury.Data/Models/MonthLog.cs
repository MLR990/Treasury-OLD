using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treasury.Data.Models
{
    [Table("MONTHLOG")]
    public class MonthLog
    {
        [Column("YEARLOGID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int YearLogId { get; set; }

        [Column("MONTH", Order = 2)]
        [Key]
        [MaxLength(15)]
        public string Month { get; set; }

        [Column("CASHBALANCE")]
        public double CashBalance { get; set; }

        [Column("CREDITBALANCE")]
        public double CreditBalance { get; set; }

        [Column("SUBTOTAL")]
        public double SubTotal { get; set; }
    }
}
