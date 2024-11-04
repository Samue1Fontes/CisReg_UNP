using Microsoft.AspNetCore.Mvc;

namespace CisReg_Website.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string SelectedRegistrationType)
        {
            if (SelectedRegistrationType == "ProfissionalDeSaude")
            {
                return RedirectToAction("PersonalInfo");
            }
            else if (SelectedRegistrationType == "UsuarioUNP")
            {
                return RedirectToAction("Create", "User");
            }

            return View();
        }

        [HttpGet]
        public IActionResult PersonalInfo()
        {
            return View();
        }

    }
}
