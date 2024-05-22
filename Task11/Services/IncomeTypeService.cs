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
        var kek = await _db.IncomeTypes.ToListAsync();
        return kek;
    }
    
    // public async Task Retrieve(int id)
    // {
    // }
    //
    // // public Task Create()
    // // {
    // // }
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