using CisReg_Website.Domain;
using CisReg_Website.Models.Vacancy;
using CisReg_Website.Models;
using MongoDB.Bson;

namespace CisReg_Website.Repositories;

public class VacancyRepository(ApplicationDbContext context)
{
  private readonly ApplicationDbContext _context = context;

  public IEnumerable<VacancyModel> GetAll()
  {
    return [.. _context.Vacancies];
  }

  public VacancyModel? GetById(ObjectId Id)
  {
    return _context.Vacancies.FirstOrDefault(v => v.Id == Id);
  }

  public IEnumerable<VacancyComplete> GetAllByQuery(VacancySchedulesMadeQueryParams Params)
  {
    var vacancies = _context.Vacancies
      .Where(v => Params.Status != null
        ? Params.Status.Contains(v.Status)
        : v.Status == Status.Occupied)
    .Where(v => string.IsNullOrEmpty(Params.InitialDate.ToString()) || v.AvailableHour > Params.InitialDate)
    .Where(v => string.IsNullOrEmpty(Params.FinalDate.ToString()) || v.AvailableHour < Params.FinalDate);

    var patients = _context.Patients.Where(p => p.Permission == Permissions.Patient);
    var professionals = _context.Professionals.Where(p => p.Permission == Permissions.Professional);
    var vacanciesComplete = new List<VacancyComplete>();

    foreach (var vacancy in vacancies)
    {
      var completeVacancy = new VacancyComplete
      {
        AvailableHour = vacancy.AvailableHour,
        Id = vacancy.Id,
        Patient = patients.FirstOrDefault(p => p.Id == vacancy.PatientId),
        Professional = professionals.FirstOrDefault(p => p.Id == vacancy.ProfessionalId)
      };

      vacanciesComplete.Add(completeVacancy);
    }

    return vacanciesComplete;
  }

  private bool IsWithinPeriod(DateTime dateTime, Period? period)
  {
    return period switch
    {
      Period.Morning => dateTime.TimeOfDay >= TimeSpan.FromHours(0) && dateTime.TimeOfDay <= TimeSpan.FromHours(12),
      Period.Afternoon => dateTime.TimeOfDay > TimeSpan.FromHours(12) && dateTime.TimeOfDay <= TimeSpan.FromHours(18),
      Period.Night => dateTime.TimeOfDay > TimeSpan.FromHours(18) && dateTime.TimeOfDay <= TimeSpan.FromHours(23).Add(TimeSpan.FromMinutes(59)),
      _ => true
    };
  }
}