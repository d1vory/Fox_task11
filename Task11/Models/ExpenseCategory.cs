using System.ComponentModel.DataAnnotations;

namespace Task11.Models;

public class ExpenseCategory
{
    public int Id { get; set; }
    
    [StringLength(50)]
    public string Name { get; set; } = null!;
    
}