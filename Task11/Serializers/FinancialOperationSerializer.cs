using Humanizer;
using Newtonsoft.Json;
using Task11.Data;
using Task11.Models;

namespace Task11.Serializers;

public class FinancialOperationSerializer
{
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public int? IncomeType { get; set; }
    public int? ExpenseType { get; set; }
    
    public decimal Amount { get; set; }
    public DateTime TimeStamp { get; set; }
    
    [JsonProperty]
    public int OperationType { get; }

    public FinancialOperationSerializer(FinancialOperation instance)
    {
        Id = instance.Id;
        Description = instance.Description;
        IncomeType = instance.IncomeTypeId;
        ExpenseType = instance.ExpenseTypeId;
        Amount = instance.Amount;
        TimeStamp = instance.TimeStamp;
        OperationType = (int) instance.Type;
    }

    [JsonConstructor]
    public FinancialOperationSerializer(string description, decimal amount,  DateTime timeStamp, int? incomeType=null, int? expenseType=null)
    {
        if ((incomeType.HasValue && expenseType.HasValue) || (!incomeType.HasValue && !expenseType.HasValue))
        {
            throw new JsonSerializationException("Provide either incomeTypeId or expenseTypeId");
        }

        if (incomeType.HasValue)
        {
            ValidateIncomeType(incomeType.Value);
            IncomeType = incomeType.Value;
        }
        if (expenseType.HasValue)
        {
            ValidateExpenseType(expenseType.Value);
            ExpenseType = expenseType.Value;
        }
        
        Description = description;
        Amount = amount;
        TimeStamp = timeStamp;
    }
    
    public FinancialOperation BuildInstance()
    {
        return new FinancialOperation(Description, Amount, TimeStamp, IncomeType, ExpenseType);
    }

    public FinancialOperation UpdateInstance(FinancialOperation instance)
    {
        instance.Description = Description;
        instance.IncomeTypeId = IncomeType;
        instance.ExpenseTypeId = ExpenseType;
        instance.Amount = Amount;
        instance.TimeStamp = TimeStamp;

        return instance;
    }
    
    public static FinancialOperationSerializer[] SerializeList(IList<FinancialOperation> objects)
    {
        var serializedObjects = new FinancialOperationSerializer[objects.Count];
        for (int i = 0; i < objects.Count; i++)
        {
            serializedObjects[i] = new FinancialOperationSerializer(objects[i]);
        }

        return serializedObjects;
    }
    
    private void ValidateIncomeType(int value)
    {
        var db = new ApplicationContext();
        if (!db.IncomeTypes.Any(ic => ic.Id == value))
        {
            throw new JsonSerializationException("This income type does not exist");
        }
    }
    
    private void ValidateExpenseType(int value)
    {
        var db = new ApplicationContext();
        if (!db.ExpenseTypes.Any(ic => ic.Id == value))
        {
            throw new JsonSerializationException("This expense type does not exist");
        }
    }
    
}