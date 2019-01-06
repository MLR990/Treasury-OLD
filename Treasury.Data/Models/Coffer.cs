using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treasury.Data.Models
{
    [Table("COFFER")]
    public class Coffer
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Column("NAME")]
        public string Name { get; set; }

        [MaxLength(1000)]
        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("MONTH")]
        public Month Month { get; set; }

        [Column("AMOUNT")]
        public double Amount { get; set; }

        [Column("AMOUNTFUNDED")]
        public double AmountFunded { get; set; }

        [Column("AMOUNTSPENT")]
        public double AmountSpent { get; set; }

        [Column("CLOSED", TypeName = "bit")]
        public Boolean Closed { get; set; }
    }
}
