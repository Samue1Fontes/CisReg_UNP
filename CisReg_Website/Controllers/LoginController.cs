using Microsoft.AspNetCore.Mvc;
using CisReg_Website.Models;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using CisReg_Website.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace CisReg_Website.Controllers
{
    public class LoginController : Controller
    {

        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Erro no envio...";
                return View();
            }
            try
            {
                var professionalTable = await _context.Professional
                     .FirstOrDefaultAsync(m => m.Email == model.Email);

                if (professionalTable == null)
                {
                    throw new ArgumentException("Usuário não existente.");
                }

                if (model.Email != professionalTable.Email || model.Password != professionalTable.Password)
                {
                    ViewBag.ErrorMessage = "Email/senha incorretos.";
                    return View("Index");
                }

                return RedirectToAction("Index", "Home");
            }
            catch (ArgumentException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            catch (DbUpdateException ex)
            {
                ViewBag.ErrorMessage = "Erro na conexão.";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erro inesperado. Tente novamente.";

            }
            return View();
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }
    }
}
