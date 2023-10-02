//using eticaret_v2.Data;
//using eticaret_v2.Models;
using eticaret_entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_v2.ViewModels
{
    public class ProductCreate
    {
        public int Id { get; set; }
        //[Required (ErrorMessage ="İsim gereklidir.")]
        //[StringLength(60, MinimumLength = 5, ErrorMessage = "En az 5 karakter girmelisiniz.")]
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string ImgUrl { get; set; }
        public int CategoryId { get; set; }
        public int OrderId { get; set; }
        public List<Category> SelectedCategory { get; set; }
     
        public bool IsApproved { get; set; }
        public List<Product> Products { get; set; }
        public string Description { get; set; }
    }
}
