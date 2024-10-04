using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CisReg_Website.Models
{
    [BindProperties]
    public class PersonalInfoModel : PageModel
    {
        public string CompleteName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime BornDate { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/register-professional-info");
            }
            return RedirectToPage("/registration-professional-info");
        }
    }
}