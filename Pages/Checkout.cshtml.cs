using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoTechStore.Data;
using EcoTechStore.Models;
using EcoTechStore.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace EcoTechStore.Pages
{
    public class CheckoutModel : PageModel
    {
        private const string SessionCartKey = "Cart";

        public List<(Product Product, int Quantity)> Items { get; set; } = new();
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

        public IActionResult OnPostComplete(string paymentMethod)
        {
            if (string.IsNullOrEmpty(paymentMethod))
            {
                return RedirectToPage();
            }

            // Limpa o carrinho após confirmação
            HttpContext.Session.Remove(SessionCartKey);

            // Redireciona para página de sucesso com método de pagamento
            return RedirectToPage("OrderConfirmation", new { method = paymentMethod });
        }
    }
}
