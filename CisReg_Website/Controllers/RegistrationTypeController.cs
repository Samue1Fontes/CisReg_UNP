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
                return RedirectToAction("Index", "UnpSup");
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
