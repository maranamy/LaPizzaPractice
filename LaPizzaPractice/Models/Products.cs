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
        public int Id { get; set; }

        [Column("product_name")]
        [Required]
        [MaxLength(250)]
        public string PizzaName { get; set; } = null!;

        [Column("category_id")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Categories Category { get; set; } = null!;

        [Column("pizza_size")]
        [Required]
        public string PizzaSize { get; set; } = null!;

        [Column("filling_description")]
        [Required]
        [MaxLength(500)]
        public string FillingDescr { get; set; } = null!;

        [Column("price")]
        public decimal Price { get; set; }
    }
}
