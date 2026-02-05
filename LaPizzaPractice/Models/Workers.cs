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
        public int Id { get; set; }


        [Column("w_name")]
        [Required]
        public string WorkerName { get; set; } = string.Empty;

        [Column("w_surname")]
        [Required]
        public string WorkerSurn { get; set; } = string.Empty;

        [Column("w_patronymic")]
        [Required]
        public string WorkerPatronimyc { get; set; } = string.Empty;

        [Column("role_id")]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Roles WorkerRole { get; set; } = null!;
    }
}
