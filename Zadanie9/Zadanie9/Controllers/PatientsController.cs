using Microsoft.AspNetCore.Mvc;
using Zadanie9.DTOs;
using Zadanie9.Services;
using Zadanie9.Models;

namespace Zadanie9.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IdBService _dbService;
    public PatientsController(IdBService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPatientsData(string? LastName = null)
    {
        var patients = await _dbService.GetPatientsData(LastName);
        
        return Ok(patients.Select(e => new GetPatientsDTO()
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Birthdate = e.Birthdate,
          
        }));
    }
}