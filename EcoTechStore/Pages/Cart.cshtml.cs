using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using EcoTechStore.Models;
using EcoTechStore.Data;
using EcoTechStore.Helpers;

namespace EcoTechStore.Pages
{
    public class CartModel : PageModel
    {
        private const string SessionCartKey = "Cart";

        public List<(Product Product, int Quantity)> Items { get; set; } = new();

        public void OnGet()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(SessionCartKey) ?? new List<CartItem>();
            var catalog = ProductCatalog.GetProducts();
            Items = cart.Select(ci => (catalog.FirstOrDefault(p => p.Id == ci.ProductId), ci.Quantity))
                        .Where(t => t.Item1 != null)
                        .ToList();
        }

        public IActionResult OnPostRemove(int id)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(SessionCartKey) ?? new List<CartItem>();
            var existing = cart.FirstOrDefault(c => c.ProductId == id);
            if (existing != null)
            {
                cart.Remove(existing);
                HttpContext.Session.SetObject(SessionCartKey, cart);
            }
            return RedirectToPage();
        }
    }
}
