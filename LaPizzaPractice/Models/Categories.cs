using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LaPizzaPractice.Models
{
    [Table("categories")]
    public class Categories
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("category_name")]
        [Required]
        [MaxLength(250)]
        public string CategoryName { get; set; } = null!;
    }
}
