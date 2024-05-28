using System.ComponentModel.DataAnnotations;
using Task11.DTO.OperationType;

namespace Task11.DTO.FinancialOperation;

public class CreateFinancialOperationDto
{
    public string Description { get; set; } = "";
    public int OperationTypeId { get; set; }
    public decimal Amount { get; set; }
    public DateTime TimeStamp { get; set; }
}