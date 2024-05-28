using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task11.DTO.OperationType;
using Task11.Models;

namespace Task11.Services;

public class OperationTypeService
{
    private readonly BaseApplicationContext _db;
    private readonly IMapper _mapper;
    
    public OperationTypeService(BaseApplicationContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<List<OperationTypeDto>> List()
    {
        var dbObjects = await _db.OperationTypes.ToListAsync();
        var kek = _db.OperationTypes.ProjectToList<OperationTypeDto>(_mapper.ConfigurationProvider);
        //var kek = _mapper.Map<OperationTypeDto>(dbObjects);
        return kek;
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