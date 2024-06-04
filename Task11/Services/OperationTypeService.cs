using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shared2.DTO.OperationType;
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
        return _db.OperationTypes.ProjectToList<OperationTypeDto>(_mapper.ConfigurationProvider);
    }
    
    public async Task<OperationTypeDto?> Retrieve(int id)
    {
        var obj = await _db.OperationTypes.FindAsync(id);
        return _mapper.Map<OperationTypeDto>(obj);
    }
    
    public async Task<OperationTypeDto> Create(CreateOperationTypeDto operationType)
    {
        await ValidateName(operationType.Name);
        var instance = _mapper.Map<OperationType>(operationType);
        await _db.OperationTypes.AddAsync(instance);
        await _db.SaveChangesAsync();
        return _mapper.Map<OperationTypeDto>(instance);
    }

    public async Task<OperationTypeDto?> Update(int instanceId, UpdateOperationTypeDto operationType)
    {
        await ValidateName(operationType.Name, instanceId);
        var instance = await _db.OperationTypes.FindAsync(instanceId);
        if (instance == null)
        {
            return null;
        }
        _mapper.Map(operationType, instance);
        _db.Entry(instance).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return _mapper.Map<OperationTypeDto>(instance);
    }

    public async Task<bool> Delete(int id)
    {
        if (await _db.FinancialOperations.AnyAsync(f => f.OperationTypeId == id))
        {
            throw new ApplicationException("There are financial operations with this type");
        }

        var instance = await _db.OperationTypes.FindAsync(id);
        if (instance == null)
        {
            return false;
        }

        _db.OperationTypes.Remove(instance);
        await _db.SaveChangesAsync();
        return true;
    }
    
    public async Task ValidateName(string value, int? id = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ApplicationException("Name should be filled");
        }
        if (await _db.OperationTypes.AnyAsync(ot => ot.Name == value && ot.Id != id))
        {
            throw new ApplicationException("This operation type already exists");
        }
    }

}