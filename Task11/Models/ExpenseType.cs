using System.ComponentModel.DataAnnotations;

namespace Task11.Models;

public class ExpenseType
{
    public int Id { get; set; }
    
    [StringLength(100)]
    public string Name { get; set; } = null!;
    
    public ExpenseCategory ExpenseCategory { get; set; } = null!;
    public int ExpenseCategoryId { get; set; }
}