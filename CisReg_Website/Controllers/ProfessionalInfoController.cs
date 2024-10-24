using Microsoft.AspNetCore.Mvc;
using CisReg_Website.Models;
using Newtonsoft.Json;
using CisReg_Website.Data;

namespace CisReg_Website.Controllers
{
    public class ProfessionalInfoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Recebe apenas as informações pessoais do profissional da saúde como informação temporária.
            var modelJson = TempData["PersonalInfo"] as string;
            var personalInfoModel = string.IsNullOrEmpty(modelJson) ? new PersonalInfoModel() : JsonConvert.DeserializeObject<PersonalInfoModel>(modelJson);

            var combinedModel = new CombinedInfoModel
            {
                CompleteName = personalInfoModel.CompleteName,
                Email = personalInfoModel.Email,
                CPF = personalInfoModel.CPF,
                BornDate = personalInfoModel.BornDate,
                Password = personalInfoModel.Password
            };

            TempData["CombinedInfo"] = JsonConvert.SerializeObject(combinedModel);

            return View("~/Views/Registration/ProfessionalInfo.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(ProfessionalInfoModel model)
        {
            var modelJson = TempData["CombinedInfo"] as string;
            var combinedModel = string.IsNullOrEmpty(modelJson) ? new CombinedInfoModel() : JsonConvert.DeserializeObject<CombinedInfoModel>(modelJson);

            combinedModel.registrationNumber = model.registrationNumber;
            combinedModel.academicTraining = model.academicTraining;
            combinedModel.specialty = model.specialty;


            if (ModelState.IsValid)
            {
                TempData["ProfessionalInfo"] = JsonConvert.SerializeObject(combinedModel);
                Database.GetInstance().Insert("profissional", combinedModel);
                return RedirectToAction("Index", "Login");
            }

            return View(); 
        }

    }
}
