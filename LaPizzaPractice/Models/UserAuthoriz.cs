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
        public int Id { get; set; }

        [Column("client_id")]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Clients ClientAutho { get; set; } = null!;

        [Column("phone")]
        [Required]
        public string ClientPhone { get; set; } = null!;

        [Column("password_hash")]
        [Required]
        public string Password { get; set; } = null!;
    }
}
