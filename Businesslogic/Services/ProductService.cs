﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businesslogic.Intefaces;
using DataAccess.Interfaces;
using ProductDB;
using ProductDB.Entities;


namespace WebApplication1.Services
{




    
    public class ProductService : IEntityService
    {
        private readonly IRepository<Product> productRepo;
        private readonly IRepository<Category> categoryRepo;

        public ProductService(IRepository<Product> productRepo,
            IRepository<Category> categorytRepo)
        {
            this.productRepo = productRepo;
            this.categoryRepo = categorytRepo;
        }

        public void Create(Product product)
        {
            //context.Products.Add(product);
            //context.SaveChanges();
            productRepo.Insert(product);
            productRepo.Save();
        }

        public void CreateCategory(Category category)
        {
            //context.Products.Add(product);
            //context.SaveChanges();
            categoryRepo.Insert(category);
            productRepo.Save();
        }

        public void DeleteCategory(int id)
        {
            //var find = context.Products.Find(id);
            var category = categoryRepo.GetByID(id);

            //context.Products.Remove(find);
            //context.SaveChanges();
            categoryRepo.Delete(category);
            categoryRepo.Save();
        }

        public void Delete(int id)
        {
            //var find = context.Products.Find(id);
            var find = GetById(id);
            if (find == null) return;

            //context.Products.Remove(find);
            //context.SaveChanges();
            productRepo.Delete(find);
            productRepo.Save();
        }

        public void Edit(Product product)
        {
            //context.Products.Update(product);
            //context.SaveChanges();
            productRepo.Update(product);
            productRepo.Save();
        }

        public List<Product> Get(int[] ids)
        {
            //return context.Products.Where(p =>ids.Contains(p.Id)).ToList();
            return productRepo.Get(p => ids.Contains(p.Id)).ToList();
        }

        public List<Product> GetAll()
        {
            //return context.Products.ToList();
            return productRepo.Get(includeProperties: new[] { "Category" }).ToList();
        }

        public Product? GetById(int id)
        {
            if (id < 0) { return null; }

            //var product = context.Products.Find(id);
            var product = productRepo.GetByID(id);

            if (product == null) { return null; }
            return product;
        }

        public Category? GetCategoryById(int id)
        {
            if (id < 0) { return null; }

            //var product = context.Products.Find(id);
            var category = categoryRepo.GetByID(id);

            if (category == null) { return null; }
            return category;
        }

        public List<Category> GetCategories()
        {
            //return context.Categories.ToList();
            return categoryRepo.Get().ToList();
        }
    }

}