using Microsoft.AspNetCore.Mvc;
using CisReg_Website.Models;
using Newtonsoft.Json;
using MongoDB.Bson;
using CisReg_Website.Domain;
using Microsoft.EntityFrameworkCore;

namespace CisReg_Website.Controllers
{
    public class ProfessionalInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfessionalInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

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

            var formationsList = _context.Formations.ToList();
            var specialtiesList = _context.Specialties.ToList();

            ViewBag.Formations = formationsList;
            ViewBag.Specialties = specialtiesList;

            return View("~/Views/Registration/ProfessionalInfo.cshtml");
        }

        public class ObjectIdConverter : JsonConverter<ObjectId>
        {
            public override ObjectId ReadJson(JsonReader reader, Type objectType, ObjectId existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                var objectIdString = reader.Value as string;
                return string.IsNullOrEmpty(objectIdString) ? ObjectId.Empty : new ObjectId(objectIdString);
            }

            public override void WriteJson(JsonWriter writer, ObjectId value, JsonSerializer serializer)
            {
                writer.WriteValue(value.ToString());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(ProfessionalInfoModel model)
        {
            var modelJson = TempData["CombinedInfo"] as string;

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new ObjectIdConverter());

            var combinedModel = string.IsNullOrEmpty(modelJson)
                ? new CombinedInfoModel()
                : JsonConvert.DeserializeObject<CombinedInfoModel>(modelJson, settings);

            combinedModel.registrationNumber = model.registrationNumber;
            combinedModel.academicTraining = model.academicTraining;
            combinedModel.specialty = model.specialty;

            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Erro no envio...";
                return View(model);
            }
            try
            {
                TempData["ProfessionalInfo"] = JsonConvert.SerializeObject(combinedModel);

                if (combinedModel.Id == ObjectId.Empty)
                {
                    combinedModel.Id = ObjectId.GenerateNewId();
                }

                _context.Add(combinedModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Login");
            }
            catch (DbUpdateException ex)
            {
                ViewBag.ErrorMessage = "Erro no envio dos dados...";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erro inesperado. Tente novamente.";
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

    }
}
