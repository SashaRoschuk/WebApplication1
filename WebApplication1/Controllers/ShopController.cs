
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductDB;
using ProductDB.Entities;
using System.Collections.Generic;

using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class ShopController : Controller
    {
        private readonly ShopDBcontext dbContext;
        
        public ShopController(ShopDBcontext context)
        {
            
            dbContext = context;
        }
     
        // GET: HomeController1
        
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)//100
        {
            var product = dbContext.Products.Find(id);
            if (product == null) { return NotFound(); }
            return View(product);
        }

        // GET: HomeController1/Create
        

        public ActionResult Products()
        {
         

            return View(dbContext.Products.ToList());
        }
        

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        

        // POST: HomeController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                dbContext.Remove(product);
                dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Products));
        }
        public IActionResult Create()
        {
            //ViewData and ViewBag
            //ViewData["List"] = new List<int> { 1, 2, 3 }; // List as Object
            ViewBag.CategoryList = new SelectList(dbContext.Categories.ToList(),
            nameof(Category.Id), nameof(Category.Name));
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDB.Entities.Product product)
        {
            //add to database
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
