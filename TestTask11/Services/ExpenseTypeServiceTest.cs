// using JetBrains.Annotations;
// using Task11.Data;
// using Task11.Models;
// using Task11.Services;
//
// namespace TestTask11.Services;
//
// [TestClass]
// [TestSubject(typeof(ExpenseTypeService))]
// public class ExpenseTypeServiceTest
// {
//
//     public InMemoryAppContext db;
//     private ExpenseTypeService _expenseTypeService;
//
//     [TestInitialize]
//     public void TestInitialize()
//     {
//         db = new InMemoryAppContext();
//         db.Database.EnsureDeleted();
//         db.Database.EnsureCreated();
//
//         _expenseTypeService = new ExpenseTypeService(db);
//     }
//
//     [TestMethod]
//     public async Task TestList()
//     {
//         var items = await _expenseTypeService.List();
//         Assert.AreEqual(ModelBuilderExtensions.DefaultExpenseTypes.Length, items.Count);
//     }
//
//     [TestMethod]
//     public async Task TestRetrieve()
//     {
//         var item = await _expenseTypeService.Retrieve(1);
//         Assert.IsNotNull(item);
//         
//         var item2 = await _expenseTypeService.Retrieve(100);
//         Assert.IsNull(item2);
//     }
//
//     [TestMethod]
//     public async Task TestCreate()
//     {
//         var item = new ExpenseType() { Name = "test", ExpenseCategoryId = 1};
//         item = await _expenseTypeService.Create(item);
//         Assert.IsNotNull(item.Id);
//         
//         var itemInDb = await db.ExpenseTypes.FindAsync(item.Id);;
//         Assert.IsNotNull(itemInDb);
//     }
//
//     [TestMethod]
//     public async Task TestUpdate()
//     {
//         var item = await db.ExpenseTypes.FindAsync(1);
//         Assert.IsNotNull(item);
//
//         var changedName = "my new changed name";
//         item.Name = changedName;
//
//         await _expenseTypeService.Update(item);
//         
//         var item2 = await db.ExpenseTypes.FindAsync(1);
//         Assert.IsNotNull(item2);
//         Assert.AreEqual(changedName, item2.Name);
//     }
//
//     [TestMethod]
//     public async Task TestDelete()
//     {
//         var finOp = new FinancialOperation("blal", 100.0M, DateTime.Now, null, 1);
//         await db.FinancialOperations.AddAsync(finOp);
//         await db.SaveChangesAsync();
//         
//         var expenseTypeWithOps = await db.ExpenseTypes.FindAsync(1);
//         Assert.IsNotNull(expenseTypeWithOps);
//         await Assert.ThrowsExceptionAsync<ApplicationException>(async () => await _expenseTypeService.Delete(expenseTypeWithOps.Id));
//         
//         await _expenseTypeService.Delete(3);
//         var item2 = await db.ExpenseTypes.FindAsync(3);
//         Assert.IsNull(item2);
//     }
//     
// }