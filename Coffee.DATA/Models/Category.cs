﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.DATA.Models
{
    public class Category : BaseEntities
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
