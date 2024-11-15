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
        
        List<Category> GetCategories();

        void CreateCategory(Category category);

        void DeleteCategory(int id);

        Category? GetCategoryById(int id);

        //void Create(Category product);
        //void Edit(Category product);
        //void Delete(int id);
    }
}
