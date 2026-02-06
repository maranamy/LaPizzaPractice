using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LaPizzaPractice.Models
{
    [Table("user_authorization")]
    public class UserAuthoriz
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("client_id")]
        [Required]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        [Required]
        public Clients ClientAutho { get; set; } = new Clients();

        [Column("phone")]
        [Required]
        [RegularExpression(@"^\+7\d{10}$", ErrorMessage ="Номер должен иметь следующий паттерн: +7хххххххххх")]
        public string ClientPhone { get; set; } = null!;

        [Column("password_hash")]
        [Required]
        [MaxLength(255)]
        public string Password { get; set; } = null!;
    }
}
