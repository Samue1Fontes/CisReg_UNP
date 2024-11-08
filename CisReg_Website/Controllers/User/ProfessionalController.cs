using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CisReg_Website.Domain;
using CisReg_Website.Models;
using MongoDB.Bson;
using CisReg_Website.Repositories;

namespace CisReg_Website.Controllers.User
{
    public class ProfessionalController(ApplicationDbContext context, ProfessionalRepository professionalRepository) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ProfessionalRepository _professionalRepository = professionalRepository;

        public IActionResult Index()
        {
            return View(_professionalRepository.GetAll());
        }

        public async Task<IActionResult> Details(ObjectId id)
        {
            var professional = await _context.Professionals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professional == null)
            {
                return NotFound();
            }

            return View(professional);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Academic,Council,CouncilNumber,Specialty,Formation,Id,Email,Password,FirstName,LastName")] Professional professional)
        {
            if (ModelState.IsValid)
            {
                professional.Permission = Permissions.Professional;
                _context.Add(professional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professional);
        }

        public async Task<IActionResult> Edit(ObjectId id)
        {
            var professional = await _context.Professionals.FindAsync(id);
            if (professional == null)
            {
                return NotFound();
            }
            return View(professional);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ObjectId id, [Bind("Academic,Council,CouncilNumber,Specialty,Formation,Id,Email,Password,FirstName,LastName,Permission")] Professional professional)
        {
            if (id != professional.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionalExists(professional.Id))
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
            return View(professional);
        }

        public async Task<IActionResult> Delete(ObjectId id)
        {
            var professional = await _context.Professionals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professional == null)
            {
                return NotFound();
            }

            return View(professional);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ObjectId id)
        {
            var professional = await _context.Professionals.FindAsync(id);
            if (professional != null)
            {
                _context.Professionals.Remove(professional);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessionalExists(ObjectId id)
        {
            return _context.Professionals.Any(e => e.Id == id);
        }
    }
}
