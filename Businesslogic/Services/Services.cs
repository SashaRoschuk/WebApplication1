using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businesslogic.Intefaces;
using ProductDB;
using ProductDB.Entities;


namespace WebApplication1.Services
{




    public interface IEntityService :  ICategoryService , IProductService
    {
        //CRUD Interface
        
    }
    public class Service : IEntityService
    {
        private readonly ShopDBcontext context;
        public Service(ShopDBcontext context)
        {
            this.context = context;
        }

        public List<Category> GetAllCategory() 
        {
           return context.Categories.ToList();
        }
        public void Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var find = context.Products.Find(id);
            if (find == null) return;

            context.Products.Remove(find);
            context.SaveChanges();
        }

        public void Edit(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            if (id < 0) { return null; }

            var product = context.Products.Find(id);

            if (product == null) { return null; }
            return product;
        }

        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }
        public List<Product> Get(int[] ids)
        {
            return context.Products.Where(p =>ids.Contains(p.Id)).ToList();
            //return productRepo.Get(p => ids.Contains(p.Id)).ToList();
        }
    }

}