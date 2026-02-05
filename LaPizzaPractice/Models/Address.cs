using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LaPizzaPractice.Models
{
    [Table("address")]
    public class Address
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("city_name")]
        [Required]
        public string CityName { get; set; } = null!;

        [Column("street_name")]
        [Required]
        public string StreetName { get; set; } = null!;

        [Column("house_number")]
        [Required]
        public string HouseNumber { get; set; } = null!;

        [Column("flat_number")]
        public string FlatNumber { get; set; }
    }
}
