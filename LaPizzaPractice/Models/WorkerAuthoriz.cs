using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LaPizzaPractice.Models
{
    [Table("worker_authorization")]
    public class WorkerAuthoriz
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("worker_id")]
        public int WorkerId { get; set; }

        [ForeignKey("WorkerId")]
        public Workers Worker { get; set; } = null!;

        [Column("login")]
        [Required]
        public string Login { get; set; } = null!;

        [Column("password_hash")]
        [Required]
        public string Password { get; set; } = null!;
    }
}
