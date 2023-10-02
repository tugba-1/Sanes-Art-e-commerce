using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_entity.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int ProductId { get; set; }
        //public List<Product> Products { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
