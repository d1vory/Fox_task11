using Microsoft.EntityFrameworkCore;
using Task11.Models;

namespace Task11.Services;

public class IncomeTypeService
{
    private readonly BaseApplicationContext _db;

    public IncomeTypeService(BaseApplicationContext db)
    {
        _db = db;
    }
    
    public async Task<List<IncomeType>> List()
    {
        return await _db.IncomeTypes.ToListAsync();
    }
    
    public async Task<IncomeType?> Retrieve(int id)
    {
        return await _db.IncomeTypes.FindAsync(id);
    }
    
    public async Task<IncomeType> Create(IncomeType incomeType)
    {
        await _db.IncomeTypes.AddAsync(incomeType);
        await _db.SaveChangesAsync();
        return incomeType;
    }
    // //
    // // public async Task Create()
    // // {
    // // }
    //
    // public async Task Update()
    // {
    // }
    //
    // public async Task Delete(int id)
    // {
    //
    // }
    //
    // public async Task ValidateName()
    // {
    // }
}