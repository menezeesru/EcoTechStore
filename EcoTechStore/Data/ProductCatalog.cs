using System.Collections.Generic;
using EcoTechStore.Models;

namespace EcoTechStore.Data
{
    public static class ProductCatalog
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Title = "Notebook EcoGreen X15", Description = "Notebook com materiais reciclados, baixo consumo energético.", Price = 4599.00m, ImageUrl = "~/images/product-notebook.svg", Category = "Computadores" },
                new Product { Id = 2, Title = "Smartphone Solar Power S10", Description = "Smartphone com recarga solar e bateria de longa duração.", Price = 2399.00m, ImageUrl = "~/images/product-phone.svg", Category = "Celulares" },
                new Product { Id = 3, Title = "Teclado BambooTech Wireless", Description = "Teclado sem fio feito de bambu sustentável.", Price = 289.00m, ImageUrl = "~/images/product-keyboard.svg", Category = "Acessórios" },
                new Product { Id = 4, Title = "Mouse EcoClick Recycled", Description = "Mouse ergonômico com plástico reciclado.", Price = 159.00m, ImageUrl = "~/images/product-mouse.svg", Category = "Acessórios" },
                new Product { Id = 5, Title = "Monitor LED EcoView 24\"", Description = "Monitor econômico com tecnologia de baixo consumo.", Price = 1199.00m, ImageUrl = "~/images/product-monitor.svg", Category = "Monitores" },
                new Product { Id = 6, Title = "Carregador Solar Portátil SunCharge", Description = "Carregador portátil movido a energia solar.", Price = 249.00m, ImageUrl = "~/images/product-charger.svg", Category = "Acessórios" },
                new Product { Id = 7, Title = "Headset EcoSound Pro", Description = "Headset com estrutura reciclável e alta qualidade sonora.", Price = 399.00m, ImageUrl = "~/images/product-headset.svg", Category = "Áudio" },
                new Product { Id = 8, Title = "Power Bank EcoEnergy 20.000mAh", Description = "Bateria portátil sustentável de alta capacidade.", Price = 299.00m, ImageUrl = "~/images/product-powerbank.svg", Category = "Acessórios" },
                new Product { Id = 9, Title = "Hub USB GreenConnect", Description = "Hub USB feito com alumínio reciclado.", Price = 189.00m, ImageUrl = "~/images/product-hub.svg", Category = "Acessórios" },
                new Product { Id = 10, Title = "Lâmpada Inteligente EcoLight Wi‑Fi", Description = "Lâmpada LED inteligente com baixo consumo.", Price = 129.00m, ImageUrl = "~/images/product-light.svg", Category = "Iluminação" }
            };
        }
    }
}
