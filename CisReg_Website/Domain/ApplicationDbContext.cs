using CisReg_Website.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace CisReg_Website.Domain;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Professional> Professionals { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<HallModel> Halls { get; set; }
    public DbSet<VacancyModel> Vacancies { get; set; }
    public DbSet<CombinedInfoModel> Professional { get; set; }
    public DbSet<FormationModel> Formations { get; set; }
    public DbSet<SpecialtyModel> Specialties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMongoDB("mongodb+srv://root:admin@cisreg.kzr70.mongodb.net/?retryWrites=true&w=majority&appName=CisReg", "cisreg");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Professional>().ToCollection("users");
        modelBuilder.Entity<Patient>().ToCollection("users");

        modelBuilder.Entity<CombinedInfoModel>().ToCollection("profissional");
        modelBuilder.Entity<FormationModel>().ToCollection("forma��o");
        modelBuilder.Entity<SpecialtyModel>().ToCollection("especialidade");
        modelBuilder.Entity<HallModel>().ToCollection("hall");
        modelBuilder.Entity<VacancyModel>().ToCollection("vacancy");
    }
}