using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_entity.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string ImgUrl { get; set; }
        public int CategoryId { get; set; }
        //public Category Category { get; set; }
        //public int CategoryId { get; set; }
        //public bool IsHome { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        //public List<ProductComment> ProductComment { get; set; }
        //public List<OrderItem> OrderItems { get; set; }
        //public Order Orders { get; set; }
        public int OrderId { get; set; }
        public bool IsApproved { get; set; }
        public string Description { get; set; }
        public int CommentId { get; set; }

    }
}
