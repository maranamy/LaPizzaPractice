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
        [Required]
        public int Id { get; set; }

        [Column("worker_id")]
        [Required]
        public int WorkerId { get; set; }

        [ForeignKey("WorkerId")]
        public Workers Worker { get; set; } = null!;


        [Column("phone")]
        [RegularExpression(@"^\+7\d{10}$", ErrorMessage = "Номер должен иметь следующий паттерн: +7хххххххххх")]
        public string? WorkerPhone { get; set; }

        [Column("email")]
        [MaxLength(150)]
        [RegularExpression(@"^[a-zA-Z0-9][a-zA-Z0-9._]{0,63}@pizza\.ru$", ErrorMessage = "Неверная структура адреса")]
        public string? Email { get; set; } 

        [Column("birthdate")]
        public DateTime Birthdate { get; set; }

        [Column("address_id")]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address WorkerAddress { get; set; } = null!;
    }
}
