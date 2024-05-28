using System.ComponentModel.DataAnnotations;

namespace Task11.Models;

public class FinancialOperation
{
    public int Id { get; set; }
    
    [StringLength(250)]
    public string Description { get; set; } = "";
    
    public OperationType? OperationType { get; set; } //TODO make required
    public int? OperationTypeId { get; set; }
    
    public decimal Amount { get; set; }
    public DateTime TimeStamp { get; set; } //TODO rename
    
    
    // public FinancialOperation(string description, decimal amount, DateTime timeStamp, OperationType operationType)
    // {
    //     Description = description;
    //     OperationType = operationType;
    //     Amount = amount;
    //     TimeStamp = timeStamp;
    // }
    //
    // public FinancialOperation(string description, decimal amount,  DateTime timeStamp, int operationTypeId)
    // {
    //     OperationTypeId = operationTypeId;
    //     Description = description;
    //     Amount = amount;
    //     TimeStamp = timeStamp;
    // }
}