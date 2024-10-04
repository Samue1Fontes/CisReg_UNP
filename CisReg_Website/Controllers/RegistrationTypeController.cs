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

            return View();
        }

        [HttpGet]
        public IActionResult PersonalInfo()
        {

            return View();
        }
    }
}
