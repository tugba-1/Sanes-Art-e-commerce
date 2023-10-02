using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_v2.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60,MinimumLength =5,ErrorMessage ="En az 5 karakter girmelisiniz.")]
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string ImgUrl { get; set; }
        //public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
