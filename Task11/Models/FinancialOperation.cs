using System.ComponentModel.DataAnnotations;

namespace Task11.Models;

public class FinancialOperation
{
    public int Id { get; set; }
    
    [StringLength(250)]
    public string Description { get; set; } = "";
    
    public IncomeType? IncomeType { get; set; }
    public int? IncomeTypeId { get; set; }
    
    public ExpenseType? ExpenseType { get; set; }
    public int? ExpenseTypeId { get; set; }
    
    public decimal Amount { get; set; }
    public DateTime TimeStamp { get; set; }

    public bool IsIncome => IncomeType != null || IncomeTypeId.HasValue;
    public bool IsExpense => ExpenseType != null || ExpenseTypeId.HasValue;
    
    
    public FinancialOperation(decimal amount, string description,  DateTime timeStamp, IncomeType? incomeType=null, ExpenseType? expenseType=null)
    {
        if ((incomeType != null && expenseType != null) || (incomeType == null && expenseType == null))
        {
            throw new ArgumentException("Provide either incomeType or expenseType");
        }
        
        Description = description;
        IncomeType = incomeType;
        ExpenseType = expenseType;
        Amount = amount;
        TimeStamp = timeStamp;
    }
    
    public FinancialOperation(decimal amount, string description,  DateTime timeStamp, int? incomeTypeId=null, int? expenseTypeId=null)
    {
        if ((incomeTypeId != null && expenseTypeId != null) || (incomeTypeId == null && expenseTypeId == null))
        {
            throw new ArgumentException("Provide either incomeTypeId or expenseTypeId");
        }
        
        Description = description;
        IncomeTypeId = incomeTypeId.Value;
        ExpenseTypeId = expenseTypeId.Value;
        Amount = amount;
        TimeStamp = timeStamp;
    }
}