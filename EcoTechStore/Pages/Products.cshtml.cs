using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using EcoTechStore.Models;
using EcoTechStore.Data;
using EcoTechStore.Helpers;

namespace EcoTechStore.Pages
{
    public class ProductsModel : PageModel
    {
        public List<Product> Products { get; set; } = new();
        public List<string> Categories { get; set; } = new();
        public string SelectedCategory { get; set; } = "";
        private const string SessionCartKey = "Cart";

        [BindProperty(SupportsGet = true)]
        public string Category { get; set; }

        public void OnGet()
        {
            // Carrega todos os produtos
            var allProducts = ProductCatalog.GetProducts();

            // Extrai categorias únicas
            Categories = allProducts
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            // Filtra por categoria se especificada
            if (!string.IsNullOrEmpty(Category))
            {
                Products = allProducts.Where(p => p.Category == Category).ToList();
                SelectedCategory = Category;
            }
            else
            {
                Products = allProducts;
            }
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
