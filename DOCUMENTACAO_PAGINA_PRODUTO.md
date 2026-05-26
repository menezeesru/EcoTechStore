# 📖 Documentação: Página Individual do Produto

## Explicação Técnica - EcoTechStore

---

## 🔗 Como Funciona a Navegação do Catálogo para Página Individual

### Fluxo de Funcionamento

Quando você clica em um produto no catálogo, o sistema realiza os seguintes passos:

1. **Clique no Catálogo** → URL é gerada com o ID do produto
2. **Roteamento** → ASP.NET Core roteia para a página Product.cshtml
3. **Busca do Produto** → Code-behind busca os dados no catálogo
4. **Renderização** → Página exibe os dados específicos do produto

---

## 1️⃣ Na Página de Catálogo (Products.cshtml)

### Código:
```razor
<a asp-page="/Product" asp-route-id="@item.Id">
    <img src="@Url.Content(item.ImageUrl)" class="card-img-top" alt="@item.Title">
</a>
<h5 class="card-title">
    <a asp-page="/Product" asp-route-id="@item.Id">@item.Title</a>
</h5>
```

### Explicação:

| Atributo | Função |
|----------|--------|
| `asp-page="/Product"` | Tag Helper que gera um link para a página `Product.cshtml` |
| `asp-route-id="@item.Id"` | Passa o ID do produto como parâmetro na URL |
| `@item.Id` | Insere dinamicamente o ID do produto (1, 2, 3, etc.) |

### Resultado:
- Clicando no primeiro produto: `localhost/Product/1`
- Clicando no segundo produto: `localhost/Product/2`
- Clicando no terceiro produto: `localhost/Product/3`

---

## 2️⃣ Na Página Individual (Product.cshtml)

### Código:
```razor
@page "{id:int}"
@model EcoTechStore.Pages.ProductModel
@{
    ViewData["Title"] = Model.Product?.Title ?? "Produto";
}
```

### Explicação:

| Parte | Significado |
|-------|------------|
| `@page "{id:int}"` | Define a rota para aceitar um parâmetro `id` do tipo inteiro |
| `@model EcoTechStore.Pages.ProductModel` | Vincula a classe C# que controla esta página |
| `Model.Product?.Title` | Usa o operador `?.` para acessar seguramente o título (null-safe) |

### Como Funciona:
- A rota `{id:int}` faz com que a página acesse a URL `/Product/{qualquer número}`
- O parâmetro `id` é automaticamente capturado da URL
- Exemplo: Em `/Product/3`, o `id` recebe o valor `3`

---

## 3️⃣ No Code-Behind (Product.cshtml.cs)

### Código Completo:
```csharp
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
            // Busca o produto no catálogo usando o ID recebido da URL
            Product = ProductCatalog.GetProducts()
                                   .FirstOrDefault(p => p.Id == id);

            // Se não encontrar o produto, retorna erro 404
            if (Product == null) 
                return NotFound();

            // Se encontrar, renderiza a página com os dados do produto
            return Page();
        }

        public IActionResult OnPostAdd(int productId, int quantity = 1)
        {
            var catalog = ProductCatalog.GetProducts();
            var p = catalog.FirstOrDefault(x => x.Id == productId);
            if (p == null || quantity < 1) 
                return RedirectToPage(new { id = productId });

            var cart = HttpContext.Session
                .GetObject<System.Collections.Generic.List<CartItem>>(SessionCartKey) 
                ?? new System.Collections.Generic.List<CartItem>();

            var existing = cart.FirstOrDefault(c => c.ProductId == productId);
            if (existing != null) 
                existing.Quantity += quantity;
            else 
                cart.Add(new CartItem { ProductId = productId, Quantity = quantity });

            HttpContext.Session.SetObject(SessionCartKey, cart);
            return RedirectToPage("/Cart");
        }
    }
}
```

### Passo a Passo:

#### 1. **Receber o ID**
```csharp
public IActionResult OnGet(int id)
```
- O método `OnGet` é chamado automaticamente quando a página é acessada via GET
- O parâmetro `id` recebe o valor da URL (ex: se URL é `/Product/3`, `id = 3`)

#### 2. **Buscar no Catálogo**
```csharp
Product = ProductCatalog.GetProducts()
                       .FirstOrDefault(p => p.Id == id);
```
- `ProductCatalog.GetProducts()` - Obtém a lista de todos os produtos
- `.FirstOrDefault(p => p.Id == id)` - Procura o primeiro produto com ID igual ao recebido
- O resultado é armazenado na propriedade `Product`

#### 3. **Validar**
```csharp
if (Product == null) 
    return NotFound();
```
- Se nenhum produto for encontrado, retorna erro 404 (Not Found)

#### 4. **Renderizar**
```csharp
return Page();
```
- Se o produto existe, renderiza a página Razor com os dados do `Model.Product`

#### 5. **Adicionar ao Carrinho**
```csharp
public IActionResult OnPostAdd(int productId, int quantity = 1)
```
- Handler chamado quando o botão "Adicionar ao Carrinho" é clicado
- Processa a adição ao carrinho via sessão HTTP

---

## 4️⃣ Exibição na Página Razor

### Código:
```razor
<h1>@Model.Product?.Title</h1>
<p class="short-desc">@Model.Product?.Description</p>
<span class="price">@(Model.Product?.Price.ToString("C") ?? string.Empty)</span>
<span class="old-price">@Model.Product?.ImageUrl</span>
```

### Explicação:

| Código | O Que Faz |
|--------|-----------|
| `@Model.Product?.Title` | Exibe o título do produto |
| `@Model.Product?.Description` | Exibe a descrição do produto |
| `@(Model.Product?.Price.ToString("C") ?? string.Empty)` | Exibe o preço formatado em moeda |
| `?.` | Operador null-conditional (segurança contra valores nulos) |
| `?? string.Empty` | Retorna string vazia se o valor for nulo |

---

## 📊 Diagrama Visual do Fluxo

```
┌─────────────────────────────────────────────────────────┐
│             PÁGINA DE CATÁLOGO                          │
│          (Products.cshtml)                              │
│                                                         │
│  Produto 1: Notebook                                    │
│  Produto 2: Smartphone                                  │
│  Produto 3: Teclado                                     │
└────────────────┬────────────────────────────────────────┘
                 │ Clica em Produto 2
                 ↓
        ┌─────────────────────────┐
        │ URL Gerada:             │
        │ /Product/2              │
        └─────────────┬───────────┘
                      │
                      ↓
    ┌─────────────────────────────────────┐
    │   ROTEAMENTO ASP.NET CORE           │
    │   @page "{id:int}"                  │
    │   id = 2                            │
    └──────────────────┬──────────────────┘
                       │
                       ↓
    ┌──────────────────────────────────────┐
    │  OnGet(int id) - id = 2              │
    │  Busca no catálogo                   │
    │  Product = Smartphone                │
    └──────────────────┬───────────────────┘
                       │
                       ↓
    ┌──────────────────────────────────────┐
    │  PÁGINA INDIVIDUAL                   │
    │  (Product.cshtml)                    │
    │                                      │
    │  Título: Smartphone Solar Power S10  │
    │  Preço: R$ 2.399,00                  │
    │  Descrição: ...                      │
    │  [Adicionar ao Carrinho]             │
    └──────────────────────────────────────┘
```

---

## 🔑 Conceitos-Chave

### 1. **Tag Helpers (asp-page e asp-route)**
- `asp-page` - Especifica para qual página rotear
- `asp-route-{nome}` - Passa valores como parâmetros de rota

### 2. **Roteamento de Página (@page)**
- `@page "{id:int}"` - Define padrão de URL que a página aceita
- `{id:int}` - Parâmetro chamado `id` que deve ser um inteiro

### 3. **Handlers (OnGet, OnPost)**
- `OnGet` - Executado quando página é acessada via GET (acesso normal)
- `OnPost` - Executado quando formulário é enviado via POST

### 4. **LINQ (Language Integrated Query)**
- `.FirstOrDefault(p => p.Id == id)` - Busca o primeiro elemento que satisfaz a condição

### 5. **Operador Null-Conditional (?.)**
- `@Model.Product?.Title` - Acessa `Title` apenas se `Product` não for nulo
- Evita erros de `NullReferenceException`

---

## 🎯 Resumo

A navegação de catálogo para página individual funciona através de:

1. **Links com parâmetro ID** - A página de catálogo cria links passando o ID
2. **Roteamento de URL** - ASP.NET Core interpreta `/Product/{id}`
3. **Method Binding** - ASP.NET chama `OnGet(int id)` com o ID extraído
4. **Busca de Dados** - Code-behind busca o produto no catálogo
5. **Renderização** - Página Razor exibe os dados do produto encontrado

Este é um padrão comum em aplicações web para exibir detalhes de um item selecionado! 🚀

---

## 📝 Arquivos Envolvidos

```
EcoTechStore/
├── Pages/
│   ├── Products.cshtml          (Catálogo com lista de produtos)
│   ├── Products.cshtml.cs       (Handler do catálogo)
│   ├── Product.cshtml           (Página individual)
│   ├── Product.cshtml.cs        (Handler da página individual)
│   └── Cart.cshtml              (Carrinho de compras)
├── Data/
│   └── ProductCatalog.cs        (Dados dos produtos)
└── Models/
    ├── Product.cs              (Modelo de Produto)
    └── CartItem.cs             (Modelo de Item do Carrinho)
```

---

**Documento gerado para EcoTechStore - .NET 10 Razor Pages**
