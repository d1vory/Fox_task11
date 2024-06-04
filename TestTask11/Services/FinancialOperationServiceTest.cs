using AutoMapper;
using JetBrains.Annotations;
using Shared2.DTO.FinancialOperation;
using Task11.Data;
using Task11.DTO;
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
        _financialOperationService = new FinancialOperationService(db, mapper);
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
        var item = new CreateFinancialOperationDto()
            { Description = "aaa", CreatedAt = new DateTime(2040, 12, 31), OperationTypeId = 1 };
        var createdItem = await _financialOperationService.Create(item);
        Assert.IsNotNull(createdItem.Id);
        
        var itemInDb = await db.FinancialOperations.FindAsync(createdItem.Id);;
        Assert.IsNotNull(itemInDb);
    }
    
    [TestMethod]
    public async Task TestUpdate()
    {
        var item = await db.FinancialOperations.FindAsync(1);
        Assert.IsNotNull(item);
    
        var changedDescription = "my new description";
        var dto = new UpdateFinancialOperationDto()
        {
            Description = changedDescription, Amount = item.Amount, CreatedAt = item.CreatedAt,
            OperationTypeId = item.OperationTypeId
        };
    
        await _financialOperationService.Update(item.Id, dto);
        
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

    
}