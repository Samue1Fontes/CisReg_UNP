using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CisReg_Website.Domain;
using CisReg_Website.Models;
using MongoDB.Bson;

namespace CisReg_Website.Controllers
{
    public class VacancyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VacancyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Vacancies.ToListAsync());
        }

        public async Task<IActionResult> Details(ObjectId id)
        {
            var vacancyModel = await _context.Vacancies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancyModel == null)
            {
                return NotFound();
            }

            return View(vacancyModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AvailableHour,PatientId,ProfessionalId,ReservedById,CreatedById,Status")] VacancyModel vacancyModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacancyModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacancyModel);
        }

        public async Task<IActionResult> Edit(ObjectId id)
        {
            var vacancyModel = await _context.Vacancies.FindAsync(id);
            if (vacancyModel == null)
            {
                return NotFound();
            }
            return View(vacancyModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ObjectId id, [Bind("Id,AvailableHour,PatientId,ProfessionalId,ReservedById,CreatedById,Status")] VacancyModel vacancyModel)
        {
            if (id != vacancyModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacancyModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyModelExists(vacancyModel.Id))
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
            return View(vacancyModel);
        }

        public async Task<IActionResult> Delete(ObjectId id)
        {
            var vacancyModel = await _context.Vacancies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancyModel == null)
            {
                return NotFound();
            }

            return View(vacancyModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ObjectId id)
        {
            var vacancyModel = await _context.Vacancies.FindAsync(id);
            if (vacancyModel != null)
            {
                _context.Vacancies.Remove(vacancyModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacancyModelExists(ObjectId id)
        {
            return _context.Vacancies.Any(e => e.Id == id);
        }
    }
}
