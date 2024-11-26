using MongoDB.Bson;

namespace CisReg_Website.Models.Vacancy;

public class VacancyAssignCreateViewModel
{
  public ObjectId ProfessionalId { get; set; }
  public ObjectId PatientId { get; set; }
}

public class VacancyAssignShowViewModel(VacancyModel vacancy, IEnumerable<Patient> patients, IEnumerable<Professional> professionals)
{
  public IEnumerable<Patient> Patients { get; set; } = patients;
  public IEnumerable<Professional> Professionals { get; set; } = professionals;
  public VacancyModel VacancyModel { get; set; } = vacancy;
  public ObjectId ProfessionalId { get; set; }
  public ObjectId PatientId { get; set; }
}