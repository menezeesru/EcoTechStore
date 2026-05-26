using System.Collections.Generic;
using System.Linq;
using EcoTechStore.Models;

namespace EcoTechStore.Data
{
    public static class ProductCatalog
    {
        private static List<Product> _products = new()
        {
            new Product 
            { 
                Id = 1, 
                Title = "Notebook EcoGreen X15", 
                Description = "Notebook com materiais reciclados, baixo consumo energético.",
                LongDescription = "O Notebook EcoGreen X15 é a solução perfeita para profissionais que buscam performance aliada à sustentabilidade. Equipado com processador de última geração e materiais reciclados, oferece o melhor custo-benefício.",
                Specifications = "Processador: AMD Ryzen 7\nMemória: 16GB DDR5\nArmazenamento: 512GB SSD\nTela: 15.6\" Full HD\nBateria: Longa duração\nSistema: Windows 11",
                Highlights = "✓ Estrutura com materiais reciclados\n✓ Baixo consumo energético\n✓ Design moderno e portátil\n✓ Menor impacto ambiental",
                Price = 4599.00m, 
                ImageUrl = "~/images/Notebook15.png", 
                Category = "Computadores" 
            },
            new Product 
            { 
                Id = 2, 
                Title = "Smartphone Solar Power S10", 
                Description = "Smartphone com recarga solar e bateria de longa duração.",
                LongDescription = "Smartphone moderno com foco em sustentabilidade, equipado com painel solar integrado para recarga complementar e fabricação com materiais de baixo impacto ambiental.",
                Specifications = "Armazenamento: 128GB\nMemória RAM: 6GB\nBateria: 5000mAh\nCarregamento: Solar + convencional\nTela: Ampla e imersiva\nCâmera: Traseira de alta qualidade\nAcabamento: Verde com design ecológico",
                Highlights = "✓ Painel solar integrado\n✓ Materiais sustentáveis\n✓ Economia de energia\n✓ Design moderno e funcional",
                Price = 2399.00m, 
                ImageUrl = "~/images/Celular.png", 
                Category = "Celulares" 
            },
            new Product 
            { 
                Id = 3, 
                Title = "Teclado e Mouse Wireless EcoWood", 
                Description = "Teclado sem fio feito de bambu sustentável.",
                LongDescription = "Conjunto sem fio com design em estilo madeira, ideal para uso diário com conforto, praticidade e visual moderno.",
                Specifications = "Conectividade: Wireless (USB)\nItens inclusos: Teclado + Mouse\nLayout: Completo\nAlimentação: Pilhas\nCompatibilidade: Windows, Linux e outros sistemas",
                Highlights = "✓ Design elegante com acabamento em madeira\n✓ Conexão sem fio\n✓ Maior organização (sem cabos)\n✓ Conforto para uso prolongado",
                Price = 289.00m, 
                ImageUrl = "~/images/Bambu.png", 
                Category = "Acessórios" 
            },
            new Product 
            { 
                Id = 4, 
                Title = "Mouse EcoClick Recycled", 
                Description = "Mouse ergonômico com plástico reciclado.",
                LongDescription = "Mouse profissional desenvolvido com plástico 100% reciclado, oferecendo conforto ergonômico e desempenho excepcional.",
                Specifications = "Material: Plástico reciclado\nConectividade: Wireless/USB\nDPI: Até 3200\nBateria: Longa duração\nDesign: Ergonômico",
                Highlights = "✓ Material 100% reciclado\n✓ Design ergonômico\n✓ Alta precisão\n✓ Econômico",
                Price = 159.00m, 
                ImageUrl = "~/images/Mouse (2).png", 
                Category = "Acessórios" 
            },
            new Product 
            { 
                Id = 5, 
                Title = "Monitor LED EcoView 24\"", 
                Description = "Monitor econômico com tecnologia de baixo consumo.",
                LongDescription = "Monitor de 24 polegadas com tecnologia LED de baixo consumo, ideal para ambientes corporativos e de trabalho remoto.",
                Specifications = "Tamanho: 24 polegadas\nResolução: Full HD 1920x1080\nPainel: IPS\nTaxa de Atualização: 60Hz\nConsumo: Otimizado",
                Highlights = "✓ Baixo consumo energético\n✓ Cores vibrantes (painel IPS)\n✓ Design slim\n✓ Suporte ajustável",
                Price = 1199.00m, 
                ImageUrl = "~/images/Monitor (1).png", 
                Category = "Monitores" 
            },
            new Product 
            { 
                Id = 6, 
                Title = "Power Bank EcoEnergy 20.000mAh", 
                Description = "Bateria portátil sustentável de alta capacidade.",
                LongDescription = "Bateria portátil com carregamento solar e USB, ideal para viagens e uso outdoor. Dotada de lanterna LED integrada e design resistente.",
                Specifications = "Capacidade: 20.000mAh\nTipo de recarga: Solar + USB\nEntradas: DC 5V/2.1A\nSaídas: 3x USB (até 5V/2.1A máx.)\nMaterial: Resistente e durável (design outdoor)\nExtras: Lanterna LED, mosquetão para transporte\nCor: Verde com detalhes em preto",
                Highlights = "✓ Recarga solar integrada\n✓ Lanterna LED\n✓ 3 portas USB\n✓ Mosquetão para transporte\n✓ Resistente e durável",
                Price = 249.00m, 
                ImageUrl = "~/images/PowerBank (1).png", 
                Category = "Acessórios" 
            },
            new Product 
            { 
                Id = 7, 
                Title = "Headset Bluetooth EcoTech Pro", 
                Description = "Headset com estrutura reciclável e alta qualidade sonora.",
                LongDescription = "Headset Bluetooth EcoTech foi desenvolvido para oferecer qualidade sonora, conforto e liberdade no seu dia a dia. Ideal para chamadas, estudos, jogos e música, com design moderno e tecnologia sem fio de alto desempenho.",
                Specifications = "Conectividade: Bluetooth 5.3\nAlcance: Até 10 metros\nBateria: Até 20 horas de uso contínuo\nCarregamento: USB\nMicrofone: Integrado com redução de ruído\nÁudio: Som estéreo de alta qualidade (graves e agudos equilibrados)\nDesign: Over-ear com almofadas macias\nExtras: Controle no headset, haste ajustável\nCor: Preto com detalhes em verde (EcoTech)",
                Highlights = "✓ Bluetooth 5.3 com alcance de 10m\n✓ Bateria de 20 horas\n✓ Design over-ear confortável\n✓ Microfone com redução de ruído\n✓ Som de alta qualidade",
                Price = 399.00m, 
                ImageUrl = "~/images/Headset (1).png", 
                Category = "Áudio" 
            },
            new Product 
            { 
                Id = 8, 
                Title = "Power Bank EcoTech 10.000 mAh", 
                Description = "Bateria portátil sustentável de alta capacidade.",
                LongDescription = "Carregador solar portátil com alta capacidade de armazenamento, perfeito para aventuras ao ar livre e uso em viagens.",
                Specifications = "Capacidade: 10.000mAh\nTipo de recarga: Solar + USB\nEntradas: DC 5V/2.1A\nSaídas: 3x USB\nMaterial: Resistente (design outdoor)\nExtras: Lanterna LED, mosquetão",
                Highlights = "✓ Recarga solar\n✓ Alta capacidade\n✓ 3 portas USB\n✓ Lanterna LED\n✓ Portável",
                Price = 189.00m, 
                ImageUrl = "~/images/PowerB.png", 
                Category = "Acessórios" 
            },
            new Product 
            { 
                Id = 9, 
                Title = "Hub USB GreenConnect", 
                Description = "Hub USB feito com alumínio reciclado.",
                LongDescription = "Hub USB de alta velocidade com construção em alumínio reciclado, oferecendo conectividade confiável para múltiplos dispositivos.",
                Specifications = "Material: Alumínio reciclado\nPortas: 7x USB 3.0\nVelocidade: Até 5Gbps\nAlimentação: Via USB\nCompatibilidade: Universal",
                Highlights = "✓ Material reciclado\n✓ 7 portas USB 3.0\n✓ Design compacto\n✓ Resistente e durável",
                Price = 189.00m, 
                ImageUrl = "~/images/USB.png", 
                Category = "Acessórios" 
            },
            new Product 
            { 
                Id = 10, 
                Title = "Lâmpada Inteligente EcoLight Wi‑Fi", 
                Description = "Lâmpada LED inteligente com baixo consumo.",
                LongDescription = "Lâmpada inteligente com conectividade Wi-Fi, permitindo controle remoto e automação de iluminação com eficiência energética.",
                Specifications = "Conectividade: Wi-Fi 2.4GHz\nTipo: LED RGB\nConsumo: Ultra-baixo (apenas 7W)\nControlador: App mobile\nDuração: 25.000 horas\nTemperatura: 2000K-6500K",
                Highlights = "✓ Controle remoto via app\n✓ Baixo consumo de energia\n✓ Cores RGB personalizáveis\n✓ Longa duração\n✓ Automação horária",
                Price = 129.00m, 
                ImageUrl = "~/images/Lampada (1).png", 
                Category = "Iluminação" 
            }
        };

        public static List<Product> GetProducts()
        {
            return _products;
        }

        public static void SaveProduct(Product product)
        {
            // Validação básica
            if (string.IsNullOrWhiteSpace(product.Title) || product.Price < 0)
            {
                return;
            }

            if (product.Id == 0)
            {
                // Novo produto - gera novo ID baseado no máximo existente
                product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
                _products.Add(product);
            }
            else
            {
                // Produto existente - atualiza
                var existing = _products.FirstOrDefault(p => p.Id == product.Id);
                if (existing != null)
                {
                    existing.Title = product.Title;
                    existing.Description = product.Description;
                    existing.LongDescription = product.LongDescription;
                    existing.Specifications = product.Specifications;
                    existing.Highlights = product.Highlights;
                    existing.Price = product.Price;
                    existing.Category = product.Category;
                    existing.ImageUrl = product.ImageUrl;
                }
            }
        }

        public static void DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}

