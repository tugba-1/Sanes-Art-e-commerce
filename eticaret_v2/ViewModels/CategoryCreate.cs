//using eticaret_v2.Data;
//using eticaret_v2.Models;
using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_v2.ViewModels
{
    public class CategoryCreate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> products { get; set; }
    }
}
