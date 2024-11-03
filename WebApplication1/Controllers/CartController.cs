using Businesslogic.Intefaces;

using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using ProductDB.Entities;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
       
            private readonly ICartService cartService;

            public CartController(ICartService service)
            {
                this.cartService = service;
            }
            public IActionResult Index()
            {
                return View(cartService.GetProducts());
            }
            public IActionResult Add(int productId, string returnUrl)
            {
                cartService.Add(productId);
                return Redirect(returnUrl);
            }

            public IActionResult Remove(int productId, string returnUrl)
            {
                cartService.Remove(productId);
                return Redirect(returnUrl);
            }
    }
    
}
