using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LaPizzaPractice.Models
{
    [Table("worker_personal_data")]
    public class WorkerPerData
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("worker_id")]
        public int WorkerId { get; set; }

        [ForeignKey("WorkerId")]
        public Workers Worker { get; set; } = null!;


        [Column("phone")]
        [Required]
        public string WorkerPhone { get; set; } = null!;

        [Column("email")]
        [Required]
        public string Email { get; set; } = null!;

        [Column("birthdate")]
        [Required]
        public DateTime Birthdate { get; set; }

        [Column("address_id")]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address WorkerAddress { get; set; } = null!;
    }
}
