using JetBrains.Annotations;
using Task11.Data;
using Task11.Models;
using Task11.Services;

namespace TestTask11.Services;

[TestClass]
[TestSubject(typeof(IncomeTypeService))]
public class IncomeTypeServiceTest
{

    public InMemoryAppContext db;
    private IncomeTypeService _incomeTypeService;

    [TestInitialize]
    public void TestInitialize()
    {
        db = new InMemoryAppContext();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        _incomeTypeService = new IncomeTypeService(db);
    }

    [TestMethod]
    public async Task TestList()
    {
        var items = await _incomeTypeService.List();
        Assert.AreEqual(ModelBuilderExtensions.DefaultIncomeTypes.Length, items.Count);
    }

    [TestMethod]
    public async Task TestRetrieve()
    {
        var item = await _incomeTypeService.Retrieve(1);
        Assert.IsNotNull(item);
        
        var item2 = await _incomeTypeService.Retrieve(100);
        Assert.IsNull(item2);
    }


    [TestMethod]
    public async Task TestCreate()
    {
        var item = new IncomeType() { Name = "test", IncomeCategoryId = 1, IsTaxable = false };
        item = await _incomeTypeService.Create(item);
        Assert.IsNotNull(item.Id);
        
        var itemInDb = await db.IncomeTypes.FindAsync(item.Id);;
        Assert.IsNotNull(itemInDb);
    }

    [TestMethod]
    public async Task TestUpdate()
    {
        var item = await db.IncomeTypes.FindAsync(1);
        Assert.IsNotNull(item);

        var changedName = "my new changed name";
        item.Name = changedName;

        await _incomeTypeService.Update(item);
        
        var item2 = await db.IncomeTypes.FindAsync(1);
        Assert.IsNotNull(item2);
        Assert.AreEqual(changedName, item2.Name);
    }

    [TestMethod]
    public async Task TestDelete()
    {
        var finOp = new FinancialOperation("blal", 100.0M, DateTime.Now, 1);
        await db.FinancialOperations.AddAsync(finOp);
        await db.SaveChangesAsync();
        
        var incomeTypeWithOps = await db.IncomeTypes.FindAsync(1);
        Assert.IsNotNull(incomeTypeWithOps);
        await Assert.ThrowsExceptionAsync<ApplicationException>(async () => await _incomeTypeService.Delete(incomeTypeWithOps.Id));
        
        await _incomeTypeService.Delete(3);
        var item2 = await db.IncomeTypes.FindAsync(3);
        Assert.IsNull(item2);
    }
    
}