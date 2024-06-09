namespace Zadanie9.DTOs;

public class GetPatientsDTO
{
    
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }

    public ICollection<GetPrescriptionDTO> Prescriptions { get; set; } = null!;
}

public class GetPrescriptionDTO
{
    public int Id { get; set; } 
    
    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    
}