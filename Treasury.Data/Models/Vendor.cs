using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treasury.Data.Models
{
    [Table("VENDOR")]
    public class Vendor
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        [Column("NAME")]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
