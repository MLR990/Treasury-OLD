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
    }
}
