using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoTechStore.Data;
using EcoTechStore.Helpers;
using EcoTechStore.Models;
using System.Linq;

namespace EcoTechStore.Pages
{
    public class ProductModel : PageModel
    {
        private const string SessionCartKey = "Cart";

        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = ProductCatalog.GetProducts().FirstOrDefault(p => p.Id == id);
            if (Product == null) return NotFound();
            return Page();
        }

        public IActionResult OnPostAdd(int productId, int quantity = 1)
        {
            var catalog = ProductCatalog.GetProducts();
            var p = catalog.FirstOrDefault(x => x.Id == productId);
            if (p == null || quantity < 1) return RedirectToPage(new { id = productId });

            var cart = HttpContext.Session.GetObject<System.Collections.Generic.List<CartItem>>(SessionCartKey) ?? new System.Collections.Generic.List<CartItem>();
            var existing = cart.FirstOrDefault(c => c.ProductId == productId);
            if (existing != null) existing.Quantity += quantity;
            else cart.Add(new CartItem { ProductId = productId, Quantity = quantity });

            HttpContext.Session.SetObject(SessionCartKey, cart);
            return RedirectToPage("/Cart");
        }
    }
}
