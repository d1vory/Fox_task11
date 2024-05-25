using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Task11.Data;
using Task11.Models;

namespace Task11.Serializers;

public class IncomeTypeSerializer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsTaxable { get; set; }
    public int IncomeCategory { get; set; }
    
    public IncomeTypeSerializer(IncomeType instance)
    {
        Id = instance.Id;
        Name = instance.Name;
        Description = instance.Description;
        IsTaxable = instance.IsTaxable;
        IncomeCategory = instance.IncomeCategoryId;
    }
    
    [JsonConstructor]
    public IncomeTypeSerializer(string name, string description, bool isTaxable, int incomeCategory, BaseApplicationContext db)
    {
        Name = name;
        Description = description;
        IsTaxable = isTaxable;
        
        ValidateIncomeCategory(incomeCategory);
        IncomeCategory = incomeCategory;
        
    }

    public IncomeType BuildInstance()
    {
        return new IncomeType()
        {
            Id = Id, Name = Name, Description = Description, IsTaxable = IsTaxable, IncomeCategoryId = IncomeCategory
        };
    }
    
    public IncomeType UpdateInstance(IncomeType instance)
    {
        instance.Name = Name;
        instance.Description = Description;
        instance.IsTaxable = IsTaxable;
        instance.IncomeCategoryId = IncomeCategory;
        return instance;
    }

    public void ValidateIncomeCategory(int value)
    {
        var db = new ApplicationContext();
        if (!db.IncomeCategories.Any(ic => ic.Id == value))
        {
            throw new JsonSerializationException("This category does not exist");
        }
    }
}