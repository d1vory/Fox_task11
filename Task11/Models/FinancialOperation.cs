using System.ComponentModel.DataAnnotations;

namespace Task11.Models;

public class FinancialOperation
{
    public int Id { get; set; }
    
    [StringLength(250)]
    public string Description { get; set; } = "";

    public OperationType OperationType { get; set; } = null!;
    public int OperationTypeId { get; set; }
    
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    
}