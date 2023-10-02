//using eticaret_v2.Data;
//using eticaret_v2.Models;
using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_v2.ViewModels
{
    public class CardModel
    {
        public int CardId { get; set; }
        public List<CardItemModel> CardItems { get; set; }
        public decimal TotalPrice()
        {
            return (decimal)CardItems.Sum(i => i.Price*i.Quantity);
        }
    }

    public class CardItemModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CardId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
    }
}
