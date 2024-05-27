using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Task11.Data;
using Task11.Models;

namespace Task11.Serializers;

public class ExpenseTypeSerializer
{
    public ExpenseTypeSerializer(ExpenseType instance)
    {
        Id = instance.Id;
        Name = instance.Name;
        ExpenseCategory = instance.ExpenseCategoryId;
    }
    
    [JsonConstructor]
    public ExpenseTypeSerializer(string name, int expenseCategory, BaseApplicationContext db)
    {
        Name = name;
        ValidateExpenseCategory(expenseCategory);
        ExpenseCategory = expenseCategory;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int ExpenseCategory { get; set; }

    public ExpenseType BuildInstance()
    {
        return new ExpenseType()
        {
            Id = Id, Name = Name, ExpenseCategoryId = ExpenseCategory
        };
    }
    
    public ExpenseType UpdateInstance(ExpenseType instance)
    {
        instance.Name = Name;
        instance.ExpenseCategoryId = ExpenseCategory;
        return instance;
    }
    
    public static ExpenseTypeSerializer[] SerializeList(IList<ExpenseType> objects)
    {
        var serializedObjects = new ExpenseTypeSerializer[objects.Count];
        for (int i = 0; i < objects.Count; i++)
        {
            serializedObjects[i] = new ExpenseTypeSerializer(objects[i]);
        }

        return serializedObjects;
    }

    public void ValidateExpenseCategory(int value)
    {
        var db = new ApplicationContext();
        if (!db.ExpenseCategories.Any(ic => ic.Id == value))
        {
            throw new JsonSerializationException("This category does not exist");
        }
    }
}