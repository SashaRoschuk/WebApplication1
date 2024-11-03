using Businesslogic.Intefaces;
using Microsoft.AspNetCore.Http;
using ProductDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class CartService : ICartService
    {
        private readonly IProductService service;
        private readonly HttpContext? httpContext;

        public CartService(IProductService service, IHttpContextAccessor httpContextAccessor)
        {
            this.service = service;
            this.httpContext = httpContextAccessor.HttpContext;
        }
        public void Add(int productId)
        {
            var productIds = httpContext.Session.GetObject<List<int>>("cart");
            if (productIds == null) { productIds = new List<int>(); }
            productIds.Add(productId);
            httpContext.Session.SetObject("cart", productIds);

        }

        public List<Product> GetProducts()
        {
            var productIds = httpContext.Session.GetObject<List<int>>("cart");
            List<Product> products = new List<Product>();


            if (productIds != null)
            {
                products = service.Get(productIds.ToArray());
            }
            return products;
        }

        public bool IsInCart(int productId)
        {
            var productIds = httpContext.Session.GetObject<List<int>>("cart");
            if (productIds == null) { return false; }
            return productIds.Contains(productId);
        }

        public void Remove(int productId)
        {
            var productIds = httpContext.Session.GetObject<List<int>>("cart");
            if (productIds == null) { productIds = new List<int>(); }
            productIds.Remove(productId);
            httpContext.Session.SetObject("cart", productIds);
        }
    }
}
