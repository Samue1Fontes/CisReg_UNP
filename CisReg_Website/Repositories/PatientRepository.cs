using CisReg_Website.Domain;
using CisReg_Website.Models;

namespace CisReg_Website.Repositories;

public class PatientRepository(ApplicationDbContext context)
{
  private readonly ApplicationDbContext _context = context;

  public IEnumerable<Patient> GetAll()
  {
    return [.. _context.Patients.Where(u => u.Permission == Permissions.Patient)];
  }
}