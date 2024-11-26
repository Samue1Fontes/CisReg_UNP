using Microsoft.AspNetCore.Mvc;
using CisReg_Website.Models;
using Newtonsoft.Json;
using CisReg_Website.Domain;
using Microsoft.EntityFrameworkCore;

namespace CisReg_Website.Controllers
{
    public class PersonalInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Submit(PersonalInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Erro no envio...";
                return View("~/Views/Registration/PersonalInfo.cshtml", model);
            }
            try
            {
                var searchForCPF = await _context.Professional
                    .FirstOrDefaultAsync(m => m.CPF == model.CPF);

                if (searchForCPF != null)
                {
                    ViewBag.ErrorMessage = "O CPF informado já está cadastrado.";
                    return View("~/Views/Registration/PersonalInfo.cshtml", model);
                }

                TempData["PersonalInfo"] = JsonConvert.SerializeObject(model);
                return RedirectToAction("Index", "ProfessionalInfo");
            }
            catch (DbUpdateException ex)
            {
                ViewBag.ErrorMessage = "Erro no envio dos dados...";

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erro inesperado. Tente novamente.";
            }

            return View("~/Views/Registration/PersonalInfo.cshtml", model);
        }

        [HttpGet]
        public IActionResult ProfessionalInfo()
        {
            return View();
        }
    }
}
