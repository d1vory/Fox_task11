
namespace Shared2.DTO.OperationType;

public class OperationTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsTaxable { get; set; }
    public bool IsIncome { get; set; }
}

