using ProductDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslogic.Intefaces
{
    public interface IProductService
    {
        //CRUD Interface
        List<Product> GetAll();
        List<Product> Get(int[] ids);
        
        Product? GetById(int id);
        void Create(Product product);
        void Edit(Product product);
        void Delete(int id);
    }
}
