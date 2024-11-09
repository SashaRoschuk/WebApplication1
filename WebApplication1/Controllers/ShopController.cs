
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductDB;
using ProductDB.Entities;
using System.Collections.Generic;
using WebApplication1.Services;
using Businesslogic.Intefaces;
using WebApplication1.Models;
using WebApplication1.Validators;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers
{
    //coment1
    public class ShopController : Controller
    {
        private readonly IEntityService service;
        ProductValidator validator = new ProductValidator();
        public ShopController(IEntityService service)
        {
            this.service = service;
        }

        // GET: HomeController1

        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id,string returnUrl = null)//100
        {
            var product = service.GetById(id);
            if (product == null) { return NotFound(); }
            ViewBag.ReturnUrl = returnUrl;
            return View(product);
        }

        // GET: HomeController1/Create


        public ActionResult Products()
        {


            return View(service.GetAll());
        }


        // GET: HomeController1/Edit/5
        public IActionResult Edit(int id)
        {
            Product p = service.GetById(id);
            if (p == null) { return NotFound(); }
            Categorylist();
            return View(p);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        public IActionResult Edit(Product p)
        {
            var validationResult = validator.Validate(p);

            if (!validationResult.IsValid)
            {
                // Обробка помилок валідації
                return View(p);
            }
            service.Edit(p);


            return RedirectToAction(nameof(Products));

        }



        // POST: HomeController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            service.Delete(id);

            return RedirectToAction(nameof(Products));
        }
        private void Categorylist()
        {
            ViewBag.CategoryList = new SelectList(service.GetCategories(),
                        nameof(Category.Id), nameof(Category.Name));
        }
        public IActionResult Create()
        {

            //ViewData and ViewBag
            //ViewData["List"] = new List<int> { 1, 2, 3 }; // List as Object
            Categorylist();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDB.Entities.Product product)
        {
            //add to database
            

            // Виконайте валідацію
            var validationResult = validator.Validate(product);

            if (!validationResult.IsValid)
            {
                // Обробка помилок валідації
                return View(product);
            }

            service.Create(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
