using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LaPizzaPractice.Models
{
    [Table("orders")]
    public class Orders
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("client_id")]
        public int ClientID { get; set; }

        [ForeignKey("ClientID")]
        public Clients Client { get; set; } = null!;

        [Column("product_id")]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Products Product { get; set; } = null!;

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("status_id")]
        public int StatusID { get; set; }

        [ForeignKey("StatusID")]
        public ActiveStatus Status { get; set; } = null!;

        [Column("is_active")]
        public bool IsActive { get; set; }


        [Column("cost")]
        public int Cost { get; set; }


        [Column("delivery_addres")]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address DelivAddress { get; set; } = null!;


        [Column("created_at")]
        public DateTime Created { get; set; }
    }
}
