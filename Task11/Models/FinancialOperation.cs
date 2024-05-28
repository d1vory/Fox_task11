using System.ComponentModel.DataAnnotations;

namespace Task11.Models;

public class FinancialOperation
{
    public int Id { get; set; }
    
    [StringLength(250)]
    public string Description { get; set; } = "";
    
    public OperationType? OperationType { get; set; }
    public int? OperationTypeId { get; set; }
    
    public decimal Amount { get; set; }
    public DateTime TimeStamp { get; set; } //TODO rename
    
    
    // public FinancialOperation(string description, decimal amount, DateTime timeStamp, IncomeType? incomeType=null, ExpenseType? expenseType=null)
    // {
    //     Description = description;
    //     IncomeType = incomeType;
    //     ExpenseType = expenseType;
    //     Amount = amount;
    //     TimeStamp = timeStamp;
    // }
    //
    // public FinancialOperation(string description, decimal amount,  DateTime timeStamp, int? incomeTypeId=null, int? expenseTypeId=null)
    // {
    //     if ((incomeTypeId != null && expenseTypeId != null) || (incomeTypeId == null && expenseTypeId == null))
    //     {
    //         throw new ArgumentException("Provide either incomeTypeId or expenseTypeId");
    //     }
    //     if (incomeTypeId.HasValue)
    //     {
    //         IncomeTypeId = incomeTypeId.Value;
    //     }
    //     if (expenseTypeId.HasValue)
    //     {
    //         ExpenseTypeId = expenseTypeId.Value;
    //     }
    //     
    //     Description = description;
    //     Amount = amount;
    //     TimeStamp = timeStamp;
    // }
}