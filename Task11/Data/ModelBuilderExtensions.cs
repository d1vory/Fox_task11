using Microsoft.EntityFrameworkCore;
using Task11.Models;

namespace Task11.Data;

public static class ModelBuilderExtensions
{
    // public static IncomeCategory[] DefaultIncomeCategories =
    // [
    //     new IncomeCategory() { Id = 1, Name = "Earned" },
    //     new IncomeCategory() { Id = 2, Name = "Passive" },
    //     new IncomeCategory() { Id = 3, Name = "Portfolio" },
    // ];
    //
    // public static IncomeType[] DefaultIncomeTypes =
    // [
    //     new IncomeType() { Id = 1, Name = "Salary", IncomeCategoryId = 1 },
    //     new IncomeType()
    //     {
    //         Id = 2, Name = "Bonus", IncomeCategoryId = 1,
    //         Description =
    //             "For example, taxi drivers and restaurant servers can earn tips. And people who work in sales can earn commissions"
    //     },
    //     new IncomeType()
    //     {
    //         Id = 3, Name = "Side hustle", IncomeCategoryId = 1,
    //         Description = "short-term jobs performing a single task on demand"
    //     },
    //     new IncomeType() { Id = 4, Name = "Rental ", IncomeCategoryId = 2 },
    //     new IncomeType() { Id = 5, Name = "Royalties", IncomeCategoryId = 2 },
    //     new IncomeType() { Id = 6, Name = "Social help", IncomeCategoryId = 2 },
    //     new IncomeType() { Id = 7, Name = "dividends ", IncomeCategoryId = 3 },
    //     new IncomeType() { Id = 8, Name = "capital gains on investments ", IncomeCategoryId = 3 },
    //     new IncomeType() { Id = 9, Name = "deposit interest", IncomeCategoryId = 3 },
    // ];
    //
    // public static ExpenseCategory[] DefaultExpenseCategories =
    // [
    //     new ExpenseCategory() { Id = 1, Name = "Food" },
    //     new ExpenseCategory() { Id = 2, Name = "Transportation" },
    //     new ExpenseCategory() { Id = 3, Name = "Housing" },
    //     new ExpenseCategory() { Id = 4, Name = "Utilities" },
    //     new ExpenseCategory() { Id = 5, Name = "Clothing" },
    //     new ExpenseCategory() { Id = 6, Name = "Personal" },
    // ];
    //
    // public static ExpenseType[] DefaultExpenseTypes =
    // [
    //     new ExpenseType() { Id = 1, Name = "Groceries", ExpenseCategoryId = 1 },
    //     new ExpenseType() { Id = 2, Name = "Restaurants", ExpenseCategoryId = 1 },
    //     new ExpenseType() { Id = 3, Name = "Gas", ExpenseCategoryId = 2 },
    //     new ExpenseType() { Id = 4, Name = "Gas", ExpenseCategoryId = 2 },
    //     new ExpenseType() { Id = 5, Name = "Repairs", ExpenseCategoryId = 2 },
    //     new ExpenseType() { Id = 6, Name = "Car payment", ExpenseCategoryId = 2 },
    //     new ExpenseType() { Id = 7, Name = "Mortgage or rent", ExpenseCategoryId = 3 },
    //     new ExpenseType() { Id = 8, Name = "Household repairs", ExpenseCategoryId = 3 },
    //     new ExpenseType() { Id = 9, Name = "Electricity", ExpenseCategoryId = 4 },
    //     new ExpenseType() { Id = 10, Name = "Water", ExpenseCategoryId = 4 },
    //     new ExpenseType() { Id = 11, Name = "Internet", ExpenseCategoryId = 4 },
    //     new ExpenseType() { Id = 12, Name = "Adults’ clothing", ExpenseCategoryId = 5 },
    //     new ExpenseType() { Id = 13, Name = "Gym memberships", ExpenseCategoryId = 6 },
    //     new ExpenseType() { Id = 14, Name = "Haircuts", ExpenseCategoryId = 6 },
    //     new ExpenseType() { Id = 15, Name = "Subscriptions", ExpenseCategoryId = 6 },
    // ];
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<IncomeCategory>().HasData(DefaultIncomeCategories);
        // modelBuilder.Entity<IncomeType>().HasData(DefaultIncomeTypes);
        // modelBuilder.Entity<ExpenseCategory>().HasData(DefaultExpenseCategories);
        // modelBuilder.Entity<ExpenseType>().HasData(DefaultExpenseTypes);
    }
}