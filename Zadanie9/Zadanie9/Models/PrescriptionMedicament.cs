﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zadanie9.Models;



[Table("Prescription_Medicament")]
[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
public class PrescriptionMedicament
{
    
    public int IdPrescription { get; set; }
    public int IdMedicament { get; set; }
    
    public int? Dose { get; set; } 
    
    [MaxLength(100)]
    public string Details { get; set; } = string.Empty;

    [ForeignKey(nameof(IdPrescription))]
    public Prescription Prescription { get; set; } = null!;
    [ForeignKey(nameof(IdMedicament))]
    public Medicament Medicament { get; set; } = null!;
    
}