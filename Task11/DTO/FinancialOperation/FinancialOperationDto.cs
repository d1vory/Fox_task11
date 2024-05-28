using System.ComponentModel.DataAnnotations;
using Task11.DTO.OperationType;

namespace Task11.DTO.FinancialOperation;

public class FinancialOperationDto
{
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public OperationTypeDto OperationType { get; set; }
    public decimal Amount { get; set; }
    public DateTime TimeStamp { get; set; }
}