using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoTechStore.Pages
{
    public class OrderConfirmationModel : PageModel
    {
        public string OrderNumber { get; set; }
        public string PaymentMethodName { get; set; }

        public void OnGet(string method)
        {
            // Gera um número de pedido aleatório
            OrderNumber = DateTime.Now.ToString("yyyyMMdd") + new Random().Next(10000, 99999).ToString();

            // Mapeia o método de pagamento para um nome amigável
            PaymentMethodName = method switch
            {
                "credit-card" => "Cartão de Crédito",
                "debit-card" => "Cartão de Débito",
                "pix" => "PIX",
                "boleto" => "Boleto Bancário",
                _ => "Desconhecido"
            };
        }
    }
}
