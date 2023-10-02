using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_entity.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Orders { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } 

        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string PaymentType { get; set; }
        public decimal TotalPrice { get; set; }
    }
}