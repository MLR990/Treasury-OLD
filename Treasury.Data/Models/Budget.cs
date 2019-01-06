using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treasury.Data.Models
{
    [Table("BUDGET")]
    public class Budget
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(75)]
        [Column("NAME")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Column("DESCRIPTION")]
        public string Description { get; set; }


    }

}
