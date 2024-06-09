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
    
    
}