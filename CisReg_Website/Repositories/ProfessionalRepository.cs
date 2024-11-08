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
}