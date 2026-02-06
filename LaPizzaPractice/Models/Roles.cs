using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LaPizzaPractice.Models
{
    [Table("roles")]
    public class Roles
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("role_name")]
        [Required]
        [MaxLength(60)]
        public string RoleName { get; set; } = string.Empty;
    }
}
