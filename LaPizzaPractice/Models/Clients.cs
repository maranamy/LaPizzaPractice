using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LaPizzaPractice.Models
{
    [Table("clients")]
    public class Clients
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("cl_name")]
        [Required]
        public string ClientName { get; set; } = string.Empty;

        [Column("cl_surname")]
        [Required]
        public string ClientSurn { get; set; } = string.Empty;

        [Column("address_id")]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address ClientAddress { get; set; } = null!;

    }
}
