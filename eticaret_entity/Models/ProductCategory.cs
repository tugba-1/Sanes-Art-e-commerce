﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eticaret_entity.Models
{
    public class ProductCategory
    {
        public int ProductId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Product Product { get; set; }

    }
}
