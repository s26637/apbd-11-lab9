using System.Linq.Expressions;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Zadanie9.DTOs;
using Zadanie9.Models;
using Zadanie9.Services;

namespace Zadanie9.Controllers;

[ApiController]
public class PrescriptionsController : ControllerBase
{
    
    private readonly IdBService _dbService;
    public PrescriptionsController(IdBService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost("/orders")]

    public async Task<IActionResult> AddNewPrescription(NewPrescription newPrescription)
    {

        foreach (var VARIABLE in newPrescription.MedicamentList)
        {
            Console.Write(VARIABLE);
        }
        
        if (newPrescription.MedicamentList.Count > 9)
        {
            return BadRequest("More than 9 Medicaments");
        }

        if (newPrescription.Date > newPrescription.DueDate)
        {
            return BadRequest("Wrong dates");
        }
        
        if (!await _dbService.DoesPatientExist(newPrescription.IdPatient))
        {
               var patient = new Patient()
                        {
                            Id = newPrescription.IdPatient,
                            FirstName = newPrescription.FirstName,
                            LastName = newPrescription.LastName,
                            Birthdate = newPrescription.Birthdate
                        };
               using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
               {
                   await _dbService.AddNewPatient(patient);
    
                   scope.Complete();
               }

        }
         
            
        
        foreach (var item in newPrescription.MedicamentList)
        {
            if (!await _dbService.DoesMedicamentExist(item.IdP))
                return NotFound($"Medicament with given ID - {item} doesn't exist");
        }
        
        
        
        var prescription = new Prescription()
        {
            Date = newPrescription.Date,
            DueDate = newPrescription.DueDate,
            IdPatient = newPrescription.IdPatient,
            IdDoctor = newPrescription.IdDoctor
        };

        var prescMedicaList = new List<PrescriptionMedicament>();
        
        var myId = await _dbService.GetNewPrescriptionId();
        
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _dbService.AddNewPrescription(prescription);
            scope.Complete();
        }
        
        
        foreach (var item in newPrescription.MedicamentList)
        {
            
            prescMedicaList.Add(new PrescriptionMedicament
            { 
                IdPrescription = myId,
                IdMedicament = item.IdP,
                Dose = item.Dose,
                Details = item.Details
            });
            
        }
        
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _dbService.AddNewPrescriptionMedicament(prescMedicaList);

            scope.Complete();
        }

        return Created("api/orders", "TAK");

    }

}