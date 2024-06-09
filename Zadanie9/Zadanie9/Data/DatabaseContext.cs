using Microsoft.EntityFrameworkCore;
using Zadanie9.Models;

namespace Zadanie9.Data;

public class DatabaseContext : DbContext
{
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Patient>().HasData(new List<Patient>
            {
                new Patient {
                    Id = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Birthdate = DateTime.Parse("1990-05-28")
                },
                new Patient {
                    Id = 2,
                    FirstName = "Anna",
                    LastName = "Nowak",
                    Birthdate = DateTime.Parse("1980-09-28")

                }
            });

            modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
            {
                new Doctor {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Nowak",
                    Email = "XYZ@gmail.com"
                },
                new Doctor {
                    Id = 2,
                    FirstName = "Aleksandra",
                    LastName = "Wiśniewska",
                    Email = "ABC@gmail.com"
                }
            });

            modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
            {
                new Medicament
                {
                    Id = 1,
                    Name = "Paracetamol",
                    Description = "No desc",
                    Type = "A"
                },
                new Medicament
                {
                    Id = 2,
                    Name = "Nurofen",
                    Description = "No desc",
                    Type = "B"
                },
                new Medicament
                {
                    Id = 3,
                    Name = "Ketonal Active",
                    Description = "No desc",
                    Type = "A"
                }
            });

            modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
            {
                new Prescription
                {
                    Id = 1,
                    Date = DateTime.Parse("2024-05-28"),
                    DueDate = DateTime.Parse("2024-05-29"),
                    IdPatient = 1,
                    IdDoctor = 2
                },
                new Prescription
                {
                    Id = 2,
                    Date = DateTime.Parse("2024-05-31"),
                    DueDate = DateTime.Parse("2024-06-01"),
                    IdPatient = 1,
                    IdDoctor = 1
                },
                new Prescription
                {
                    Id = 3,
                    Date = DateTime.Parse("2024-06-01"),
                    DueDate = DateTime.Parse("2024-07-01"),
                    IdPatient = 2,
                    IdDoctor = 1
                }
            });

            modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>
            {
                new PrescriptionMedicament
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = 3,
                    Details = "max"
                },
                new PrescriptionMedicament
                {
                    IdMedicament = 1,
                    IdPrescription = 3,
                    Dose = 4,
                    Details = "min"
                },
                new PrescriptionMedicament
                {
                    IdMedicament = 2,
                    IdPrescription = 2,
                    Dose = 2,
                    Details = "few"

                },
                new PrescriptionMedicament
                {
                    IdMedicament = 2,
                    IdPrescription = 1,
                    Dose = 12,
                    Details = "plenty"

                }
            });
    }
    
}