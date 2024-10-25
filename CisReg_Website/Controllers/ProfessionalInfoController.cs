using Microsoft.AspNetCore.Mvc;
using CisReg_Website.Models;
using Newtonsoft.Json;
using CisReg_Website.Data;
using MongoDB.Bson;

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

            var formacao = Database.GetInstance().Select("formação", null);
            var especialidade = Database.GetInstance().Select("especialidade", null);

            ViewBag.Formacao = formacao;
            ViewBag.Especialidade = especialidade;

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
        public IActionResult Submit(ProfessionalInfoModel model)
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


            if (ModelState.IsValid)
            {
                TempData["ProfessionalInfo"] = JsonConvert.SerializeObject(combinedModel);

                if (combinedModel.Id == ObjectId.Empty)
                {
                    combinedModel.Id = ObjectId.GenerateNewId();
                }

                Database.GetInstance().Insert("profissional", combinedModel);
                return RedirectToAction("Index", "Login");
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
