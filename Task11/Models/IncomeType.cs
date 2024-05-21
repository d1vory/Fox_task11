using System.ComponentModel.DataAnnotations;

namespace Task11.Models;

public class IncomeType
{
    public int Id { get; set; }
    
    [StringLength(100)]
    public string Name { get; set; } = null!;
    
    [StringLength(250)]
    public string Description { get; set; } = "";
    
    public bool IsTaxable { get; set; } = true;
    
    public IncomeCategory IncomeCategory { get; set; } = null!;
    public int IncomeCategoryId { get; set; }
    
}