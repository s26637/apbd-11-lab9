using Zadanie9.Data;
using Zadanie9.Models;
using Microsoft.EntityFrameworkCore;


namespace Zadanie9.Services;

public class DbService : IdBService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Patient>> GetPatientsData(string? patientLastName)
    {
        return await _context.Patients
           
            .Where(e => e.LastName == null || e.LastName == patientLastName)
            .ToListAsync();
    }


    public async Task<bool> DoesPatientExist(int patientID)
    {
        return await _context.Patients.AnyAsync(e => e.Id == patientID);
    }

    public async Task<bool> DoesMedicamentExist(int medicamentID)
    {
        return await _context.Medicaments.AnyAsync(e => e.Id == medicamentID);
    }

    public async Task AddNewPatient(Patient patient)
    {
        await _context.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task AddNewPrescription(Prescription prescription)
    {
        await _context.AddAsync(prescription);
        await _context.SaveChangesAsync();
    }

    public async Task<int> GetNewPrescriptionId()
    {
        int maxId = await _context.Prescriptions.MaxAsync(e => (int?)e.Id) ?? 0;
        return maxId;
    }

    public async Task AddNewPrescriptionMedicament(IEnumerable<PrescriptionMedicament> prescriptionMedicament)
    {
        
        await _context.AddRangeAsync(prescriptionMedicament);
        await _context.SaveChangesAsync();
    }


}