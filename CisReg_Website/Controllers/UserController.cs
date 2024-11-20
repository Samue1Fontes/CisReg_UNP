using Microsoft.AspNetCore.Mvc;
using CisReg_Website.Domain;
using MongoDB.Bson;
using CisReg_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace CisReg_Website.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult SchedulesMade()
        {
            return View();
        }
    }
}
