using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoTechStore.Data;
using EcoTechStore.Models;
using System.Linq;

namespace EcoTechStore.Pages.Admin
{
    public class ProductFormModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; } = new();

        public bool IsEdit { get; set; }

        public IActionResult OnGet(int? id)
        {
            // Verifica se está autenticado
            if (HttpContext.Session.GetString("AdminAuthenticated") != "true")
            {
                return RedirectToPage("/Login");
            }

            if (id.HasValue)
            {
                IsEdit = true;
                Product = ProductCatalog.GetProducts().FirstOrDefault(p => p.Id == id);
                if (Product == null) return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            // Verifica autenticação
            if (HttpContext.Session.GetString("AdminAuthenticated") != "true")
            {
                return RedirectToPage("/Login");
            }

            // Validações básicas
            if (string.IsNullOrWhiteSpace(Product.Title))
            {
                ModelState.AddModelError("Product.Title", "O título do produto é obrigatório");
            }

            if (string.IsNullOrWhiteSpace(Product.Description))
            {
                ModelState.AddModelError("Product.Description", "A descrição é obrigatória");
            }

            if (Product.Price < 0)
            {
                ModelState.AddModelError("Product.Price", "O preço não pode ser negativo");
            }

            if (string.IsNullOrWhiteSpace(Product.Category))
            {
                ModelState.AddModelError("Product.Category", "A categoria é obrigatória");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            ProductCatalog.SaveProduct(Product);
            return RedirectToPage("Products");
        }
    }
}
