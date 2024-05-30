using Shared.DTO.OperationType;

namespace Shared.DTO.FinancialOperation;

public class FinancialOperationDto
{
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public OperationTypeDto OperationType { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}