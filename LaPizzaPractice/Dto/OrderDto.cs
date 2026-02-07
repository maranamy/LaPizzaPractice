using System;
using System.Collections.Generic;
using System.Text;

namespace LaPizzaPractice.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string? PizzaName { get; set; }     
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public int StatusId { get; set; }
        public string? FullAddress { get; set; }
    }
}
