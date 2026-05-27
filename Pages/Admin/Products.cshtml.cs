using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoTechStore.Data;
using EcoTechStore.Models;
using System.Collections.Generic;

namespace EcoTechStore.Pages.Admin
{
    public class AdminProductsModel : PageModel
    {
        public List<Product> Products { get; set; } = new();

        public IActionResult OnGet()
        {
            // Verifica se está autenticado
            if (HttpContext.Session.GetString("AdminAuthenticated") != "true")
            {
                return RedirectToPage("/Login");
            }
            Products = ProductCatalog.GetProducts();
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            // Verifica autenticação
            if (HttpContext.Session.GetString("AdminAuthenticated") != "true")
            {
                return RedirectToPage("/Login");
            }
            ProductCatalog.DeleteProduct(id);
            return RedirectToPage();
        }
    }
}
