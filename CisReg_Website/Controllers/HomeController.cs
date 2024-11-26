using Microsoft.AspNetCore.Mvc;

namespace CisReg_Website.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}