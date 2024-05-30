using Shared.DTO.FinancialOperation;

namespace Shared.DTO.Reports;

public class FinOpReportDto
{
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }
    public List<FinancialOperationDto> OperationsList { get; set; }
}