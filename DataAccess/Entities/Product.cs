using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDB.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Image { get; set; }
        public string? Description { get; set; } = string.Empty;
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public int Price { get; set; }
        public ICollection<Cart> carts { get; set; }
    }
}
