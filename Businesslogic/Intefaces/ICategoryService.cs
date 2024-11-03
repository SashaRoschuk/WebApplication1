using ProductDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslogic.Intefaces
{
    public interface ICategoryService
    {
        //CRUD Interface
        
        List<Category> GetAllCategory();
       
        //void Create(Category product);
        //void Edit(Category product);
        //void Delete(int id);
    }
}
