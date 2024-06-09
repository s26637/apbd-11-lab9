using System.ComponentModel.DataAnnotations;

namespace Zadanie9.Models;

public class Medicament
{
    [Key]
    public int Id{ get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Type { get; set; } = string.Empty;
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicament { get; set; } = new HashSet<PrescriptionMedicament>();

}