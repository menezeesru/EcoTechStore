using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoTechStore.Pages
{
    public class LoginModel : PageModel
    {
        public string ErrorMessage { get; set; }

        public IActionResult OnGet()
        {
            // Se já está autenticado, redireciona para admin
            if (HttpContext.Session.GetString("AdminAuthenticated") == "true")
            {
                return RedirectToPage("/Admin/Products");
            }
            ErrorMessage = null;
            return Page();
        }

        public IActionResult OnPost(string username, string password)
        {
            // Credenciais de teste
            if (username == "adm" && password == "123")
            {
                HttpContext.Session.SetString("AdminAuthenticated", "true");
                HttpContext.Session.SetString("AdminUsername", username);
                return RedirectToPage("/Admin/Products");
            }

            ErrorMessage = "Usuário ou senha inválidos!";
            return Page();
        }
    }
}
