using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadanie9.Models;

public class Prescription
{
    [Key]
    public int Id { get; set; }
    
    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
    
    
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }

    [ForeignKey(nameof(IdPatient))]
    public Patient Patient { get; set; } = null!;

    [ForeignKey(nameof(IdDoctor))]
    public Doctor Doctor { get; set; } = null!;
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicament { get; set; } = new HashSet<PrescriptionMedicament>();

}