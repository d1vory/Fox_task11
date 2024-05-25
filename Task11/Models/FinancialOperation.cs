using System.ComponentModel.DataAnnotations;

namespace Task11.Models;

public class FinancialOperation
{
    public enum OperationTypeChoices
    {
        Income = 1,
        Expense = 2
    }
    
    public int Id { get; set; }
    
    [StringLength(250)]
    public string Description { get; set; } = "";
    
    public IncomeType? IncomeType { get; set; }
    public int? IncomeTypeId { get; set; }
    
    public ExpenseType? ExpenseType { get; set; }
    public int? ExpenseTypeId { get; set; }
    
    public decimal Amount { get; set; }
    public DateTime TimeStamp { get; set; }

    public OperationTypeChoices Type
    {
        get
        {
            if (IncomeType != null || IncomeTypeId.HasValue)
            {
                return OperationTypeChoices.Income;
            }
            return OperationTypeChoices.Expense;
        }
    }

    public bool IsIncome => IncomeType != null || IncomeTypeId.HasValue;
    public bool IsExpense => ExpenseType != null || ExpenseTypeId.HasValue;
    
    
    public FinancialOperation(string description, decimal amount, DateTime timeStamp, IncomeType? incomeType=null, ExpenseType? expenseType=null)
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
    
    public FinancialOperation(string description, decimal amount,  DateTime timeStamp, int? incomeTypeId=null, int? expenseTypeId=null)
    {
        if ((incomeTypeId != null && expenseTypeId != null) || (incomeTypeId == null && expenseTypeId == null))
        {
            throw new ArgumentException("Provide either incomeTypeId or expenseTypeId");
        }
        if (incomeTypeId.HasValue)
        {
            IncomeTypeId = incomeTypeId.Value;
        }
        if (expenseTypeId.HasValue)
        {
            ExpenseTypeId = expenseTypeId.Value;
        }
        
        Description = description;
        Amount = amount;
        TimeStamp = timeStamp;
    }
}