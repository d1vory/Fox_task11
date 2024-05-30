
namespace Shared.DTO.OperationType;

public class UpdateOperationTypeDto
{
    public string Name { get; set; }
    public string Description { get; set; } = "";
    public bool IsTaxable { get; set; }
    public bool IsIncome { get; set; }
}

