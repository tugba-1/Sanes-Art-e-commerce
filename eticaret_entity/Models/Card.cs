using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_entity.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CardItems> CardItems { get; set; }
    }
}
