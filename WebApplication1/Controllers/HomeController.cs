using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEntityService service;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IEntityService service)
        {
            this.service = service;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(service.GetAll());
        }
        public IActionResult Plane()
        {
            return View();
        }
        public IActionResult History()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}