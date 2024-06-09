using System.ComponentModel.DataAnnotations;

namespace Zadanie9.DTOs;

public class NewPrescription
{
    
    [Required]
    public int IdPatient { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }

    [Required]
    public DateTime Birthdate { get; set; }
    
    [Required]
    public int IdDoctor { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
   
    [Required]
    public DateTime DueDate { get; set; }
    
    
    public ICollection<MedicamentDTO> Medicament { get; set; } = new List<MedicamentDTO>();

    
}

public class MedicamentDTO
{
    [Required] 
    public int IdP;
    
    public int Dose { get; set; }
    
    [Required] 
    public string Details { get; set; }

}