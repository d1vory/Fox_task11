using JetBrains.Annotations;
using Task11.Data;
using Task11.Models;
using Task11.Services;

namespace TestTask11.Services;

[TestClass]
public class FinancialOperationServiceTest
{

    public InMemoryAppContext db;
    private FinancialOperationService _financialOperationService;

    public static FinancialOperation[] DefaultFinancialOperations =
    [
        new FinancialOperation("a", 100M, new DateTime(2024, 4, 19), 1, null),
        new FinancialOperation("b", 100M, new DateTime(2024, 4, 20), 1, null),
        new FinancialOperation("c", 100M, new DateTime(2024, 4, 21), 1, null),
        new FinancialOperation("d", 100M, new DateTime(2024, 4, 19), null, 1),
        new FinancialOperation("e", 100M, new DateTime(2024, 4, 20), null, 1),
        new FinancialOperation("f", 100M, new DateTime(2024, 4, 21), null, 1),
    ];

    [TestInitialize]
    public async Task TestInitialize()
    {
        Console.WriteLine("============================================================================");
        db = new InMemoryAppContext();
        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();
        
        await db.FinancialOperations.AddRangeAsync(DefaultFinancialOperations);
        await db.SaveChangesAsync();

        _financialOperationService = new FinancialOperationService(db);
    }

    [TestMethod]
    public async Task TestList()
    {
        var items = await _financialOperationService.List();
        Assert.AreEqual(DefaultFinancialOperations.Length, items.Count);
    }

    [TestMethod]
    public async Task TestRetrieve()
    {
        var item = await _financialOperationService.Retrieve(1);
        Assert.IsNotNull(item);
        
        var item2 = await _financialOperationService.Retrieve(100);
        Assert.IsNull(item2);
    }


    [TestMethod]
    public async Task TestCreate()
    {
        var item = new FinancialOperation("aaa", 100M, new DateTime(2040, 12, 31), 1, null);
        item = await _financialOperationService.Create(item);
        Assert.IsNotNull(item.Id);
        
        var itemInDb = await db.FinancialOperations.FindAsync(item.Id);;
        Assert.IsNotNull(itemInDb);
    }

    [TestMethod]
    public async Task TestUpdate()
    {
        var item = await db.FinancialOperations.FindAsync(1);
        Assert.IsNotNull(item);

        var changedDescription = "my new description";
        item.Description = changedDescription;

        await _financialOperationService.Update(item);
        
        var item2 = await db.FinancialOperations.FindAsync(1);
        Assert.IsNotNull(item2);
        Assert.AreEqual(changedDescription, item2.Description);
    }

    [TestMethod]
    public async Task TestDelete()
    {
        await _financialOperationService.Delete(1);
        var item2 = await db.FinancialOperations.FindAsync(1);
        Assert.IsNull(item2);
    }
    
    [TestMethod]
    public async Task TestGetPeriodicReport()
    {
        var startDate = new DateTime(2024, 4, 19);
        var endDate = new DateTime(2024, 4, 20);

        var reportForSingleDay = await _financialOperationService.GetPeriodicReport(startDate);
        Assert.AreEqual(100M, reportForSingleDay.TotalIncome);
        Assert.AreEqual(100M, reportForSingleDay.TotalExpense);
        Assert.AreEqual(2, reportForSingleDay.Operations.Count);
        
        var reportForPeriod = await _financialOperationService.GetPeriodicReport(startDate, endDate);
        Assert.AreEqual(200M, reportForPeriod.TotalIncome);
        Assert.AreEqual(200M, reportForPeriod.TotalExpense);
        Assert.AreEqual(4, reportForPeriod.Operations.Count);
    }
    
}