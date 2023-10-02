//using eticaret_v2.Data;
//using eticaret_v2.Models;
using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_v2.ViewModels
{
    public class OrderListModel
    {
        public int OrderId { get; set; }
        public int SiparisNo { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserId { get; set; }
        //public List<Product> Products { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string PaymentId { get; set; }
        public string ConversationId { get; set; }
        //public EnumPaymentType PaymentType { get; set; }
        //public EnumOrderState OrderState { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<Order> orders { get; set; }
        public decimal TotalPrice()
        {
            return (decimal)OrderItems.Sum(i => i.Price * i.Quantity);
        }
    }
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
    }

}
