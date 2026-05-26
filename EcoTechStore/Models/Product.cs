using System;

namespace EcoTechStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        // Mantém compatibilidade: alguns lugares usam "Title", outros usam "Name"
        public string Title { get; set; }

        public string Name
        {
            get => Title;
            set => Title = value;
        }
        public string Description { get; set; }
        public string LongDescription { get; set; }  // Descrição completa
        public string Specifications { get; set; }    // Especificações em formato texto
        public string Highlights { get; set; }        // Diferenciais em formato texto
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
    }
}
