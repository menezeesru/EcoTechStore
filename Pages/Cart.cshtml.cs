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
    public class CartItemUpdate
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class CartModel : PageModel
    {
        private const string SessionCartKey = "Cart";

        public List<(Product Product, int Quantity)> Items { get; set; } = new();

        // total do carrinho
        public decimal Total { get; set; }

        public void OnGet()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(SessionCartKey) ?? new List<CartItem>();
            var catalog = ProductCatalog.GetProducts();
            Items = cart.Select(ci => (catalog.FirstOrDefault(p => p.Id == ci.ProductId), ci.Quantity))
                        .Where(t => t.Item1 != null)
                        .ToList();

            Total = Items.Sum(i => i.Product.Price * i.Quantity);
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

        // Atualiza a quantidade do produto no carrinho
        public IActionResult OnPostUpdate(List<CartItemUpdate> items)
        {
            if (items == null || items.Count == 0)
            {
                return RedirectToPage();
            }

            var cart = HttpContext.Session.GetObject<List<CartItem>>(SessionCartKey) ?? new List<CartItem>();

            foreach (var item in items)
            {
                if (item.Quantity < 1)
                {
                    var existing = cart.FirstOrDefault(c => c.ProductId == item.ProductId);
                    if (existing != null) cart.Remove(existing);
                }
                else
                {
                    var existing = cart.FirstOrDefault(c => c.ProductId == item.ProductId);
                    if (existing != null)
                    {
                        existing.Quantity = item.Quantity;
                    }
                }
            }

            HttpContext.Session.SetObject(SessionCartKey, cart);
            return RedirectToPage();
        }
    }
}
