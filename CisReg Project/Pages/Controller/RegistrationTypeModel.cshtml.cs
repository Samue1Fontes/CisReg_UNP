using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CisReg_Project.Pages.Controller
{
    public class RegistrationTypeViewModel
    {
        public string SelectedRegistrationType { get; set; } = string.Empty;
    }

    public class RegistrationTypeModel : PageModel
    {
        [BindProperty]
        public RegistrationTypeViewModel ViewModel { get; set; } = new();

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(ViewModel.SelectedRegistrationType))
            {
                ModelState.AddModelError(string.Empty, "Por favor, selecione um tipo de cadastro.");
                return Page();
            }

            return RedirectToPage("/registration-personal-info");
        }
    }
    
}
