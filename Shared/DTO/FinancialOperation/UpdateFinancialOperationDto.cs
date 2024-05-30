namespace Shared2.DTO.FinancialOperation;

public class UpdateFinancialOperationDto
{
    public string Description { get; set; }
    public int OperationTypeId { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}