using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Task11.Models;
using Task11.Services;

namespace Task11.Controllers;

public class ExpenseTypeController
{
    private readonly ExpenseTypeService _expenseTypeService;
    
    public ExpenseTypeController(ExpenseTypeService expenseTypeService)
    {
        _expenseTypeService = expenseTypeService;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseType>>> List()
    {
        return Ok(await _expenseTypeService.List());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseType>> Retrieve(int id)
    {
        var obj = await _expenseTypeService.Retrieve(id);
        if (obj == null)
        {
            return NotFound();
        }
    
        var serializer = new ExpenseTypeSerializer(obj);
        var serialized = JsonConvert.SerializeObject(serializer);
        return Ok(serialized);
    }
    
    [HttpPost]
    public async Task<ActionResult<ExpenseType>> Create(ExpenseTypeSerializer expenseTypeSerializer)
    {
        var expenseType = await _expenseTypeService.Create(expenseTypeSerializer.BuildInstance());
        return CreatedAtAction(nameof(Retrieve), new { id = expenseType.Id }, expenseType);
    }
}