using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CisReg_Project.Pages.Controller
{
    public class RegistrationTypeModel : PageModel
    {

        // Variável para armazenar o tipo de cadastro selecionado
        [BindProperty]
        public string SelectedRegistrationType { get; set; } = "";

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(SelectedRegistrationType))
            {

                return RedirectToPage("/registration-personal-info");
            }

            return RedirectToPage("/registration-personal-info");
        }
    }
}
