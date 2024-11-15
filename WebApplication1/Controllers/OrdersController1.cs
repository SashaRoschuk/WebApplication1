using Businesslogic.Intefaces;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IMailService mailService;
        private string GetUseId() => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        private string UserName => User.FindFirstValue(ClaimTypes.Name)!;
        public OrdersController(IOrderService orderService,IMailService mailService)
        {
            this.orderService = orderService;
            this.mailService = mailService;
        }
        // [AllowAnonymous]
        public IActionResult Index()
        {
            return View(orderService.GetAll(GetUseId()));
        }

        public IActionResult Create()
        {
            //create order
            //id
            //date.now
            //cartService.GetProducts

            orderService.Create(GetUseId());
            mailService.SendMailAsync("Test","Order was confirmed!",UserName);

            return RedirectToAction(nameof(Index));
        }
    }
}
