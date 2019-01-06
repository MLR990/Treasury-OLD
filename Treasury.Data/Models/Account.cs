using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treasury.Data.Models
{
    [Table("ACCOUNT")]
    public class Account
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(75)]
        [Column("NAME")]
        public string Name { get; set; }

        [Column("BALANCE")]
        public double Balance { get; set; }

        [Column("TYPE")]
        public AccountTypes Type { get; set; }

    }

    public enum AccountTypes
    {
        Checking,
        Savings,
        Credit,
        Investment,
        Cash
    }
}
