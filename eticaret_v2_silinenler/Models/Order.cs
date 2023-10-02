using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_v2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int SiparisNo { get; set; }
        public DateTime DateAdded { get; set; }
        public List<Product> Products { get; set; }
    }
}
