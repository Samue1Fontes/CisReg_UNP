using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CisReg_Website.Domain;
using CisReg_Website.Models;
using MongoDB.Bson;
using CisReg_Website.Repositories;

namespace CisReg_Website.Controllers.User
{
    public class PatientController(ApplicationDbContext context, PatientRepository patientRepository) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        private readonly PatientRepository _patientRepository = patientRepository;

        public IActionResult Index()
        {
            return View(_patientRepository.GetAll());
        }

        public async Task<IActionResult> Details(ObjectId id)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Cnes,BirthDate,SusCard,Phone,FatherName,MotherName,Id,Email,Password,FirstName,LastName,Permission")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                patient.Permission = Permissions.Patient;
                _context.Add(patient);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        public async Task<IActionResult> Edit(ObjectId id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ObjectId id, [Bind("Cnes,BirthDate,SusCard,Phone,FatherName,MotherName,Id,Email,Password,FirstName,LastName,Permission")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id))
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
            return View(patient);
        }

        public async Task<IActionResult> Delete(ObjectId id)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ObjectId id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(ObjectId id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}
