namespace Shared.DTO.FinancialOperation;

public class CreateFinancialOperationDto
{
    public string Description { get; set; } = "";
    public int OperationTypeId { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}