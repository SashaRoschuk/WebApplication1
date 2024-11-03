using ProductDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDB.Entities
{
    
        public class Cart
        {
            public int Id { get; set; }
            //public int UserId { get; set; }
            public ICollection<Product> Products { get; set; }
        }
}
