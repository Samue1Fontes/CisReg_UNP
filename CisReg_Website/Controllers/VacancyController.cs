using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CisReg_Website.Domain;
using CisReg_Website.Models.Vacancy;
using MongoDB.Bson;
using CisReg_Website.Repositories;

namespace CisReg_Website.Controllers
{
    public class VacancyController(ApplicationDbContext context, PatientRepository patientRepository, ProfessionalRepository professionalRepository, VacancyRepository vacancyRepository) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        private readonly PatientRepository _patientRepository = patientRepository;
        private readonly ProfessionalRepository _professionalRepository = professionalRepository;
        private readonly VacancyRepository _vacancyRepository = vacancyRepository;

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
        public async Task<IActionResult> Create([Bind("AvailableHour")] VacancyModel vacancyModel)
        {
            if (ModelState.IsValid)
            {
                vacancyModel.Status = Status.Available;
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

        public IActionResult Assign(ObjectId Id)
        {
            var professionals = _professionalRepository.GetAll();
            var patients = _patientRepository.GetAll();
            var vacancy = _vacancyRepository.GetById(Id);

            if (vacancy is null)
            {
                return NotFound();
            }

            var vacancyAssignViewModel = new VacancyAssignShowViewModel(vacancy, patients, professionals);

            return View(vacancyAssignViewModel);
        }

        [HttpPost, ActionName("Assign")]
        [ValidateAntiForgeryToken]
        public IActionResult AssignConfimed(ObjectId Id, [Bind("PatientId,ProfessionalId")] VacancyAssignCreateViewModel vacancyAssignViewModel)
        {
            var vacancy = _vacancyRepository.GetById(Id);

            if (vacancy is null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                vacancy.PatientId = vacancyAssignViewModel.PatientId;
                vacancy.ProfessionalId = vacancyAssignViewModel.ProfessionalId;
                vacancy.Status = Status.Occupied;

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View();
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

        public IActionResult SchedulesMade(VacancySchedulesMadeQueryParams QueryParams)
        {
            var schedules = _vacancyRepository.GetAllByQuery(QueryParams);
            var specialties = _professionalRepository.GetAllSpecialties();
            VacancySchedulesMadeViewModel viewModel = new(schedules, specialties, QueryParams);

            return View(viewModel);
        }

        private bool VacancyModelExists(ObjectId id)
        {
            return _context.Vacancies.Any(e => e.Id == id);
        }
    }
}
