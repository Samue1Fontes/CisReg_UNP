using Microsoft.AspNetCore.Mvc;

namespace CisReg_Website.Controllers;

public class HomeController : Controller
{
  public IActionResult Index()
  {
    return View();
  }
}