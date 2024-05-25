using Microsoft.EntityFrameworkCore;
using Task11.Models;

namespace Task11.Services;

public class FinancialOperationService
{
    private readonly BaseApplicationContext _db;

    public FinancialOperationService(BaseApplicationContext db)
    {
        _db = db;
    }
    
    public async Task<List<FinancialOperation>> List()
    {
        return await _db.FinancialOperations.ToListAsync();
    }
    
    public async Task<FinancialOperation?> Retrieve(int id)
    {
        return await _db.FinancialOperations.FindAsync(id);
    }
    
    public async Task<FinancialOperation> Create(FinancialOperation incomeType)
    {
        await _db.FinancialOperations.AddAsync(incomeType);
        await _db.SaveChangesAsync();
        return incomeType;
    }

    public async Task<FinancialOperation> Update(FinancialOperation incomeType)
    {
        _db.FinancialOperations.Update(incomeType);
        await _db.SaveChangesAsync();
        return incomeType;
    }
    
    public async Task Delete(int id)
    {
        var instance = await _db.FinancialOperations.FindAsync(id);
        if (instance == null)
        {
            return;
        }

        _db.FinancialOperations.Remove(instance);
        await _db.SaveChangesAsync();
    }
}