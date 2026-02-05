using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LaPizzaPractice.Models
{
    [Table("active_status")]
    public class ActiveStatus
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("status_name")]
        [Required]
        public string StatusName { get; set; } = null!;
    }
}
