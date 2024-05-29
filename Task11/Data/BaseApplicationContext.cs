using Microsoft.EntityFrameworkCore;
using Task11.Data;
using Task11.Models;

public class BaseApplicationContext: DbContext
{
    public DbSet<OperationType> OperationTypes { get; set; } = null!;
    public DbSet<FinancialOperation> FinancialOperations { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
    }
}