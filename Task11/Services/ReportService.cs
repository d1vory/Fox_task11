using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task11.DTO.FinancialOperation;
using Task11.DTO.Reports;
using Task11.Models;

namespace Task11.Services;

public class ReportService
{
    private readonly BaseApplicationContext _db;
    private readonly IMapper _mapper;

    public ReportService(BaseApplicationContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<FinOpReportDto> GetDailyReport(DateTime date)
    {
        return await GetPeriodicReport(date);
    }
    
    public async Task<FinOpReportDto> GetPeriodicReport(DateTime startDate, DateTime? endDate=null)
    {
        IQueryable<FinancialOperation> operationsOnDate;
        if (!endDate.HasValue)
        {
            operationsOnDate = _db.FinancialOperations
                .Include(f=> f.OperationType)
                .Where(f => f.CreatedAt.Date == startDate.Date);
        }
        else
        {
            operationsOnDate = _db.FinancialOperations
                .Include(f=> f.OperationType)
                .Where(f => f.CreatedAt.Date >= startDate.Date && f.CreatedAt.Date <= endDate.Value.Date);
        }
        var totalIncome = await operationsOnDate.Where(f=> f.OperationType.IsIncome).SumAsync(f => f.Amount);
        var totalExpense = await operationsOnDate.Where(f=> !f.OperationType.IsIncome).SumAsync(f => f.Amount);
        var operationsList = operationsOnDate.ProjectToList<FinancialOperationDto>(_mapper.ConfigurationProvider);

        return new FinOpReportDto()
        {
            TotalIncome = totalIncome,
            TotalExpense = totalExpense,
            OperationsList = operationsList
        };
    }
}