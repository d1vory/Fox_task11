using Microsoft.EntityFrameworkCore;
using Task11.Models;

namespace Task11.Services;

public class FinancialOperationService
{
    private readonly BaseApplicationContext _db;

    public record Report
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public List<FinancialOperation> Operations { get; set; }
    }

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
    
    public async Task<FinancialOperation> Create(FinancialOperation instance)
    {
        await _db.FinancialOperations.AddAsync(instance);
        await _db.SaveChangesAsync();
        return instance;
    }

    public async Task<FinancialOperation> Update(FinancialOperation instance)
    {
        _db.FinancialOperations.Update(instance);
        await _db.SaveChangesAsync();
        return instance;
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
    
    public async Task<Report> GetPeriodicReport(DateTime startDate, DateTime? endDate=null)
    {
        IQueryable<FinancialOperation> operationsOnDate;
        if (!endDate.HasValue)
        {
            operationsOnDate = _db.FinancialOperations.Where(f => f.TimeStamp.Date == startDate.Date);
        }
        else
        {
            operationsOnDate = _db.FinancialOperations.Where(f => f.TimeStamp.Date >= startDate.Date && f.TimeStamp.Date <= endDate.Value.Date);
        }
        var totalIncome = await operationsOnDate.Where(f=> f.IncomeTypeId != null).SumAsync(f => f.Amount);
        var totalExpense = await operationsOnDate.Where(f=> f.ExpenseTypeId != null).SumAsync(f => f.Amount);
        return new Report()
        {
            TotalIncome = totalIncome, TotalExpense = totalExpense, Operations = await operationsOnDate.ToListAsync()
        };
    }
}