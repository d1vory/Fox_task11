using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task11.DTO.FinancialOperation;
using Task11.Models;

namespace Task11.Services;

public class FinancialOperationService
{
    private readonly BaseApplicationContext _db;
    private readonly IMapper _mapper;
    
    public FinancialOperationService(BaseApplicationContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<List<FinancialOperationDto>> List(DateTime? startDate, DateTime? endDate)
    {
        IQueryable<FinancialOperation> objects = _db.FinancialOperations
            .Include(f => f.OperationType);
        if (startDate != null)
        {
            objects = objects.Where(f => f.TimeStamp.Date >= startDate.Value.Date);
        }
        if (endDate != null)
        {
            objects = objects.Where(f => f.TimeStamp.Date <= endDate.Value.Date);
        }

        return objects.ProjectToList<FinancialOperationDto>(_mapper.ConfigurationProvider);
     }
    
    public async Task<FinancialOperationDto?> Retrieve(int id)
    {
        var obj = await _db.FinancialOperations
            .Include(f => f.OperationType)
            .FirstOrDefaultAsync(f => f.Id == id);
        return _mapper.Map<FinancialOperationDto>(obj);
    }
    
    public async Task<FinancialOperationDto> Create(CreateFinancialOperationDto operationDto)
    {
        await ValidateOperationType(operationDto.OperationTypeId);
        var instance = _mapper.Map<FinancialOperation>(operationDto);
        await _db.FinancialOperations.AddAsync(instance);
        await _db.SaveChangesAsync();
        await _db.Entry(instance).Reference(f=>f.OperationType).LoadAsync();
        return _mapper.Map<FinancialOperationDto>(instance);
    }

    public async Task<FinancialOperationDto?> Update(int instanceId, UpdateFinancialOperationDto operationDto)
    {
        var instance = await _db.FinancialOperations.FindAsync(instanceId);
        if (instance == null)
        {
            return null;
        }
        await ValidateOperationType(operationDto.OperationTypeId);
        _mapper.Map(operationDto, instance);
        _db.Entry(instance).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        await _db.Entry(instance).Reference(f=>f.OperationType).LoadAsync();
        return _mapper.Map<FinancialOperationDto>(instance);
    }
    
    public async Task<bool> Delete(int id)
    {
        var instance = await _db.FinancialOperations.FindAsync(id);
        if (instance == null)
        {
            return false;
        }

        _db.FinancialOperations.Remove(instance);
        await _db.SaveChangesAsync();
        return true;
    }
    
    public async Task ValidateOperationType(int value)
    {
        if (! await _db.OperationTypes.AnyAsync(ot => ot.Id == value))
        {
            throw new ApplicationException("This income type does not exist");
        }
    }
}