using AutoMapper;
using JetBrains.Annotations;
using Shared2.DTO.OperationType;
using Task11.Data;
using Task11.DTO;
using Task11.Models;
using Task11.Services;

namespace TestTask11.Services;

[TestClass]
[TestSubject(typeof(OperationTypeService))]
public class OperationTypeServiceTest
{

    public InMemoryAppContext db;
    private OperationTypeService _operationTypeService;
    
    [TestInitialize]
    public void TestInitialize()
    {
        db = new InMemoryAppContext();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        var mappingProfile = new DomainToResponseMappingProfile();
        var config = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));

        var mapper = config.CreateMapper();
        _operationTypeService = new OperationTypeService(db, mapper);
    }

    [TestMethod]
    public async Task TestList()
    {
        var items = await _operationTypeService.List();
        Assert.AreEqual(ModelBuilderExtensions.DefaultOperationTypes.Length, items.Count);
    }

    [TestMethod]
    public async Task TestRetrieve()
    {
        var item = await _operationTypeService.Retrieve(1);
        Assert.IsNotNull(item);
        
        var item2 = await _operationTypeService.Retrieve(100);
        Assert.IsNull(item2);
    }


    [TestMethod]
    public async Task TestCreate()
    {
        var item = new CreateOperationTypeDto() { Name = "test", Description = "my descriptionasa", IsTaxable = false, IsIncome = true};
        var createdItem = await _operationTypeService.Create(item);
        Assert.IsNotNull(createdItem.Id);
        
        var itemInDb = await db.OperationTypes.FindAsync(createdItem.Id);;
        Assert.IsNotNull(itemInDb);
    }

    [TestMethod]
    public async Task TestUpdate()
    {
        var item = await db.OperationTypes.FindAsync(1);
        Assert.IsNotNull(item);

        var changedName = "my new changed name";

        var dto = new UpdateOperationTypeDto()
        {
            Name = changedName, Description = item.Description, IsIncome = item.IsIncome, IsTaxable = item.IsTaxable
        };
        await _operationTypeService.Update(item.Id, dto);
        
        var item2 = await db.OperationTypes.FindAsync(1);
        Assert.IsNotNull(item2);
        Assert.AreEqual(changedName, item2.Name);
    }

    [TestMethod]
    public async Task TestDelete()
    {
        var finOp = new FinancialOperation(){Description = "testset", Amount = 100M, OperationTypeId = 1, CreatedAt = DateTime.Now};
        await db.FinancialOperations.AddAsync(finOp);
        await db.SaveChangesAsync();
        
        var operationTypeWithOps = await db.OperationTypes.FindAsync(1);
        Assert.IsNotNull(operationTypeWithOps);
        await Assert.ThrowsExceptionAsync<ApplicationException>(async () => await _operationTypeService.Delete(operationTypeWithOps.Id));
        
        await _operationTypeService.Delete(3);
        var item2 = await db.OperationTypes.FindAsync(3);
        Assert.IsNull(item2);
    }
    
    [TestMethod]
    public async Task TestValidateName()
    {
        var item = await db.OperationTypes.FindAsync(2);
        Assert.IsNotNull(item);

        await _operationTypeService.ValidateName(item.Name, item.Id);

        await Assert.ThrowsExceptionAsync<ApplicationException>(async () => await _operationTypeService.ValidateName(item.Name));
        await Assert.ThrowsExceptionAsync<ApplicationException>(async () => await _operationTypeService.ValidateName(null));
        await Assert.ThrowsExceptionAsync<ApplicationException>(async () => await _operationTypeService.ValidateName(""));

    }
    
}