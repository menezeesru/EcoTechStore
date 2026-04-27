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
        private const string SessionCartKey = "Cart";

        public void OnGet()
        {
            // Sample catalog items added to the page model. Replace with DB access as needed.
            Products = new List<Product>
            {
                new Product { Title = "Notebook EcoGreen X15", Description = "Notebook com materiais reciclados, baixo consumo energético.", Price = 4599.00m, ImageUrl = "~/images/product-notebook.svg", Category = "Computadores" },
                new Product { Title = "Smartphone Solar Power S10", Description = "Smartphone com recarga solar e bateria de longa duração.", Price = 2399.00m, ImageUrl = "~/images/product-phone.svg", Category = "Celulares" },
                new Product { Title = "Teclado BambooTech Wireless", Description = "Teclado sem fio feito de bambu sustentável.", Price = 289.00m, ImageUrl = "~/images/product-keyboard.svg", Category = "Acessórios" },
                new Product { Title = "Mouse EcoClick Recycled", Description = "Mouse ergonômico com plástico reciclado.", Price = 159.00m, ImageUrl = "~/images/product-mouse.svg", Category = "Acessórios" },
                new Product { Title = "Monitor LED EcoView 24\"", Description = "Monitor econômico com tecnologia de baixo consumo.", Price = 1199.00m, ImageUrl = "~/images/product-monitor.svg", Category = "Monitores" },
                new Product { Title = "Carregador Solar Portátil SunCharge", Description = "Carregador portátil movido a energia solar.", Price = 249.00m, ImageUrl = "~/images/product-charger.svg", Category = "Acessórios" },
                new Product { Title = "Headset EcoSound Pro", Description = "Headset com estrutura reciclável e alta qualidade sonora.", Price = 399.00m, ImageUrl = "~/images/product-headset.svg", Category = "Áudio" },
                new Product { Title = "Power Bank EcoEnergy 20.000mAh", Description = "Bateria portátil sustentável de alta capacidade.", Price = 299.00m, ImageUrl = "~/images/product-powerbank.svg", Category = "Acessórios" },
                new Product { Title = "Hub USB GreenConnect", Description = "Hub USB feito com alumínio reciclado.", Price = 189.00m, ImageUrl = "~/images/product-hub.svg", Category = "Acessórios" },
                new Product { Title = "Lâmpada Inteligente EcoLight Wi‑Fi", Description = "Lâmpada LED inteligente com baixo consumo.", Price = 129.00m, ImageUrl = "~/images/product-light.svg", Category = "Iluminação" }
            };
        }
    }
}
