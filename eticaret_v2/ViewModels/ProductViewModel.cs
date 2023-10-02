//using eticaret_v2.Data;
//using eticaret_v2.Models;
using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_v2.ViewModels
{
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentCategory { get; set; }
        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }
    }
    public class ProductViewModel
    {
        public List<Category> categorys { get; set; }
        public PageInfo PageInfo { get; set; }
        public List<Product> products { get; set; }
    }
}
