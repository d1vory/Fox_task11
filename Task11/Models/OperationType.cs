namespace Task11.Models;

public class OperationType
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = "";
    public bool IsTaxable { get; set; } = true;
    public bool IsIncome { get; set; }
}