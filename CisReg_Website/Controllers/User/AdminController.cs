using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CisReg_Website.Domain;
using CisReg_Website.Models;
using MongoDB.Bson;

namespace CisReg_Website.Controllers.User
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserHall.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(ObjectId? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userHall = await _context.UserHall
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userHall == null)
            {
                return NotFound();
            }

            return View(userHall);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HallModel,Phone,Id,Email,Password,FirstName,LastName,Permission")] UserHall userHall)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userHall);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userHall);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(ObjectId? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userHall = await _context.UserHall.FindAsync(id);
            if (userHall == null)
            {
                return NotFound();
            }
            return View(userHall);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ObjectId id, [Bind("HallModel,Phone,Id,Email,Password,FirstName,LastName,Permission")] UserHall userHall)
        {
            if (id != userHall.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userHall);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserHallExists(userHall.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userHall);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(ObjectId? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userHall = await _context.UserHall
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userHall == null)
            {
                return NotFound();
            }

            return View(userHall);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ObjectId id)
        {
            var userHall = await _context.UserHall.FindAsync(id);
            if (userHall != null)
            {
                _context.UserHall.Remove(userHall);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserHallExists(ObjectId id)
        {
            return _context.UserHall.Any(e => e.Id == id);
        }
    }
}
