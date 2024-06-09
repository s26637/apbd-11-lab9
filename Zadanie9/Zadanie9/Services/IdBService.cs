using Zadanie9.Models;

namespace Zadanie9.Services;

public interface IdBService
{
    Task<ICollection<Patient>> GetPatientsData(string? patientLastName);
    Task<bool> DoesPatientExist(int patientID);
    Task<bool> DoesMedicamentExist(int medicamentID);
    Task AddNewPatient(Patient patient);
    Task AddNewPrescription(Prescription prescription);
    Task<int> GetNewPrescriptionId();
    Task AddNewPrescriptionMedicament(IEnumerable<PrescriptionMedicament> prescriptionMedicament);

    
}