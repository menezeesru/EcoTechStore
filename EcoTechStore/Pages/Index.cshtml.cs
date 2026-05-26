using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoTechStore.Data;
using EcoTechStore.Models;
using EcoTechStore.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace EcoTechStore.Pages
{
    public class IndexModel : PageModel
    {
        public Product FeaturedProduct { get; set; }
        private const string SessionCartKey = "Cart";

        public void OnGet()
        {
            // Carrega o notebook (ID 1) como produto em destaque
            FeaturedProduct = ProductCatalog.GetProducts().FirstOrDefault(p => p.Id == 1);
        }

        public IActionResult OnPostAdd(int productId, int quantity = 1)
        {
            var catalog = ProductCatalog.GetProducts();
            var product = catalog.FirstOrDefault(x => x.Id == productId);
            if (product == null || quantity < 1) return RedirectToPage();

            var cart = HttpContext.Session.GetObject<List<CartItem>>(SessionCartKey) ?? new List<CartItem>();
            var existing = cart.FirstOrDefault(c => c.ProductId == productId);
            if (existing != null) existing.Quantity += quantity;
            else cart.Add(new CartItem { ProductId = productId, Quantity = quantity });

            HttpContext.Session.SetObject(SessionCartKey, cart);
            return RedirectToPage("/Cart");
        }
    }
}
