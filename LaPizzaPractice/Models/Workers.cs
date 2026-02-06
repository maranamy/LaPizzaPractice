using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LaPizzaPractice.Models
{
    [Table("workers")]
    public class Workers
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }


        [Column("w_name")]
        [Required]
        [MaxLength(80)]
        public string WorkerName { get; set; } = string.Empty;

        [Column("w_surname")]
        [Required]
        [MaxLength(80)]
        public string WorkerSurn { get; set; } = string.Empty;

        [Column("w_patronymic")]
        [MaxLength(80)]
        public string? WorkerPatronimyc { get; set; }

        [Column("role_id")]
        [Required]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        [Required]
        public Roles WorkerRole { get; set; } = null!;
    }
}
