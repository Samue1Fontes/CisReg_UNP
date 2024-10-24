using Microsoft.AspNetCore.Mvc;
using CisReg_Website.Models;
using Newtonsoft.Json;

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
        [ValidateAntiForgeryToken]
        public IActionResult Submit(PersonalInfoModel model)
        {

            if (ModelState.IsValid)
            {
                TempData["PersonalInfo"] = JsonConvert.SerializeObject(model);
                return RedirectToAction("Index", "ProfessionalInfo");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ProfessionalInfo()
        {
            return View();
        }
    }
}
