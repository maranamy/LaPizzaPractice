using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Windows.Data;

namespace LaPizzaPractice.Models
{
    [Table("products")]
    public class Products
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("product_name")]
        [Required]
        [MaxLength(150)]
        public string PizzaName { get; set; } = null!;

        [Column("category_id")]
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Categories Category { get; set; } = null!;

        [Column("pizza_size")]
        [MaxLength(50)]
        public string? PizzaSize { get; set; } 

        [Column("filling_description")]
        [MaxLength(500)]
        public string? FillingDescr { get; set; } 

        [Column("price")]
        [Required]
        public decimal Price { get; set; }
    }
}
