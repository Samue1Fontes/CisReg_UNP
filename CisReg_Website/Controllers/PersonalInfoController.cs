using Microsoft.AspNetCore.Mvc;
using CisReg_Website.Models;

namespace CisReg_Website.Controllers
{
    public class PersonalInfoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(PersonalInfoModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("RegisterProfessionalInfo");
            }

            return View(model);
        }

        public IActionResult RegisterProfessionalInfo()
        {
            return View();
        }
    }
}
