
using AutoMapper;

namespace Task11.DTO.OperationType;

public class CreateOperationTypeDto
{
    public string Name { get; set; }
    public string Description { get; set; } = "";
    public bool IsTaxable { get; set; }
    public bool IsIncome { get; set; }
}

