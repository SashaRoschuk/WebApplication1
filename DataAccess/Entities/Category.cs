﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDB.Entities
{
   public class Category
    {
        public string Name { get; set; }
        

        public ICollection<Product> Products { get; set; }

        public int Id { get; set; }
    }
}
