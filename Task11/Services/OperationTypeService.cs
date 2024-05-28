using Microsoft.EntityFrameworkCore;
using Task11.Models;

namespace Task11.Services;

public class OperationTypeService
{
    private readonly BaseApplicationContext _db;

    public OperationTypeService(BaseApplicationContext db)
    {
        _db = db;
    }
    
    public async Task<List<OperationType>> List()
    {
        return await _db.OperationTypes.ToListAsync();
    }
    
    public async Task<OperationType?> Retrieve(int id)
    {
        return await _db.OperationTypes.FindAsync(id);
    }
    
    public async Task<OperationType> Create(OperationType operationType)
    {
        await _db.OperationTypes.AddAsync(operationType);
        await _db.SaveChangesAsync();
        return operationType;
    }

    public async Task<OperationType> Update(OperationType operationType)
    {
        _db.OperationTypes.Update(operationType);
        await _db.SaveChangesAsync();
        return operationType;
    }
    
    public async Task Delete(int id)
    {
        // if (await _db.FinancialOperations.AnyAsync(f=> f.OperationTypeId==id))
        // {
        //     throw new ApplicationException("There are financial operations with this income type");
        // }
        
        var instance = await _db.OperationTypes.FindAsync(id);
        if (instance == null)
        {
            return;
        }

        _db.OperationTypes.Remove(instance);
        await _db.SaveChangesAsync();
    }

}