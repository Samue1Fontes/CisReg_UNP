using CisReg_Website.Domain;
using CisReg_Website.Models;

namespace CisReg_Website.Repositories;

public class ProfessionalRepository(ApplicationDbContext context)
{
  private readonly ApplicationDbContext _context = context;

  public IEnumerable<Professional> GetAll()
  {
    return [.. _context.Professionals.Where(u => u.Permission == Permissions.Professional)];
  }

  public IEnumerable<string> GetAllSpecialties()
  {
    return [.. _context.Professionals
    .Where(u => u.Permission == Permissions.Professional)
    .Select(u => u.Specialty)
    .Where(s => !string.IsNullOrEmpty(s))
    .Distinct()
    .Select(s => s!)];
  }
}