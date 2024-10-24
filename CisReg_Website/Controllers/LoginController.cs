using Microsoft.AspNetCore.Mvc;

namespace CisReg_Website.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
