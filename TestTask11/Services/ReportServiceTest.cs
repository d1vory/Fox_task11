using AutoMapper;
using Task11.Data;
using Task11.DTO;
using Task11.Models;
using Task11.Services;

namespace TestTask11.Services;

[TestClass]
public class ReportServiceTest
{
    public InMemoryAppContext db;
    private ReportService _reportService;
    
    public static FinancialOperation[] DefaultFinancialOperations =
    [
        new FinancialOperation(){Description = "a", Amount = 100M, CreatedAt = new DateTime(2024, 4, 19), OperationTypeId = 1},
        new FinancialOperation(){Description = "b", Amount = 100M, CreatedAt = new DateTime(2024, 4, 20), OperationTypeId = 1},
        new FinancialOperation(){Description = "c", Amount = 100M, CreatedAt = new DateTime(2024, 4, 21), OperationTypeId = 1},
        
        new FinancialOperation(){Description = "d", Amount = 100M, CreatedAt = new DateTime(2024, 4, 19), OperationTypeId = 10},
        new FinancialOperation(){Description = "e", Amount = 100M, CreatedAt = new DateTime(2024, 4, 20), OperationTypeId = 10},
        new FinancialOperation(){Description = "f", Amount = 100M, CreatedAt = new DateTime(2024, 4, 21), OperationTypeId = 10}
    ];

    [ClassInitialize]
    public static void ClassInit(TestContext testContext)
    {
        var context = new InMemoryAppContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        context.FinancialOperations.AddRange(DefaultFinancialOperations);
        context.SaveChanges();

    }
    
    [TestInitialize]
    public void TestInitialize()
    {
        var mappingProfile = new DomainToResponseMappingProfile();
        var config = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));

        var mapper = config.CreateMapper();
        db = new InMemoryAppContext();
        _reportService = new ReportService(db, mapper);
    }


    [TestMethod]
    public async Task TestDailyReport()
    {
        var startDate = new DateTime(2024, 4, 19);
        var reportForSingleDay = await _reportService.GetPeriodicReport(startDate);
        Assert.AreEqual(100M, reportForSingleDay.TotalIncome);
        Assert.AreEqual(100M, reportForSingleDay.TotalExpense);
        Assert.AreEqual(2, reportForSingleDay.OperationsList.Count);
    }
    
    
    [TestMethod]
    public async Task TestGetPeriodicReport()
    {
        var startDate = new DateTime(2024, 4, 19);
        var endDate = new DateTime(2024, 4, 20);
        
        var reportForPeriod = await _reportService.GetPeriodicReport(startDate, endDate);
        Assert.AreEqual(200M, reportForPeriod.TotalIncome);
        Assert.AreEqual(200M, reportForPeriod.TotalExpense);
        Assert.AreEqual(4, reportForPeriod.OperationsList.Count);
    }
}