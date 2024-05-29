using Microsoft.EntityFrameworkCore;
using Task11.Models;

namespace Task11.Data;

public static class ModelBuilderExtensions
{
    public static OperationType[] DefaultOperationTypes =
    [
        new OperationType() { Id = 1, Name = "Salary", Description = "from working", IsTaxable = true, IsIncome = true},
        new OperationType() { Id = 2, Name = "Bonus", Description = "tips and comissions etc", IsTaxable = true, IsIncome = true},
        new OperationType() { Id = 3, Name = "Side hustle", Description = "short-term jobs performing a single task on demand", IsTaxable = true, IsIncome = true},
        new OperationType() { Id = 4, Name = "Rental", IsTaxable = true, IsIncome = true},
        new OperationType() { Id = 5, Name = "Royalties", Description = "from nice investments", IsTaxable = true, IsIncome = true},
        new OperationType() { Id = 6, Name = "dividends", Description = "from nice investments 2", IsTaxable = false, IsIncome = true},
        new OperationType() { Id = 7, Name = "Food",  IsTaxable = true, IsIncome = true},
        new OperationType() { Id = 8, Name = "Transportation",  IsTaxable = false, IsIncome = false},
        new OperationType() { Id = 9, Name = "Housing",  IsTaxable = false, IsIncome = false},
        new OperationType() { Id = 10, Name = "Utilities", IsTaxable = false, IsIncome = false},
        new OperationType() { Id = 11, Name = "Clothing",  IsTaxable = false, IsIncome = false},
        new OperationType() { Id = 12, Name = "Personal", IsTaxable = false, IsIncome = false},
    ];

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OperationType>().HasData(DefaultOperationTypes);
    }
}