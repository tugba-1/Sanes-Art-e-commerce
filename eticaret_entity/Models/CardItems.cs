using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_entity.Models
{
    public class CardItems
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        //public static double Sum(Func<object, object> p)
        //{
        //    throw new NotImplementedException();
        //}

        public int CardId { get; set; }
        public Card Card { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
