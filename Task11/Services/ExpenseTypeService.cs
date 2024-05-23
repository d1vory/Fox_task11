using Microsoft.EntityFrameworkCore;
using Task11.Models;

namespace Task11.Services;

public class ExpenseTypeService
{
    private readonly BaseApplicationContext _db;

    public ExpenseTypeService(BaseApplicationContext db)
    {
        _db = db;
    }
    
    public async Task<List<ExpenseType>> List()
    {
        return await _db.ExpenseTypes.ToListAsync();
    }
    
    public async Task<ExpenseType?> Retrieve(int id)
    {
        return await _db.ExpenseTypes.FindAsync(id);
    }
    
    public async Task<ExpenseType> Create(ExpenseType expenseType)
    {
        await _db.ExpenseTypes.AddAsync(expenseType);
        await _db.SaveChangesAsync();
        return expenseType;
    }

    public async Task<ExpenseType> Update(ExpenseType expenseType)
    {
        _db.ExpenseTypes.Update(expenseType);
        await _db.SaveChangesAsync();
        return expenseType;
    }
    
    public async Task Delete(int id)
    {
        var instance = await _db.ExpenseTypes.FindAsync(id);
        if (instance == null)
        {
            return;
        }

        _db.ExpenseTypes.Remove(instance);
        await _db.SaveChangesAsync();
    }

}