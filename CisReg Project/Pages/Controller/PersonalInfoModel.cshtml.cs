using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CisReg_Project.Pages.Controller
{
    public class PersonalInfoModel : PageModel
    {
        [BindProperty]
        public string SelectedRegistrationType { get; set; } = "";

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            return Page();
        }
    }
}
