using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Task11.Models;
using Task11.Serializers;
using Task11.Services;

namespace Task11.Controllers;

[Route("api/income_type")]
[ApiController]
public class IncomeTypeController: ControllerBase
{
    private readonly IncomeTypeService _incomeTypeService;

    public IncomeTypeController(IncomeTypeService incomeTypeService)
    {
        _incomeTypeService = incomeTypeService;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<IncomeType>>> List()
    {
        return Ok(await _incomeTypeService.List());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IncomeType>> Retrieve(int id)
    {
        var obj = await _incomeTypeService.Retrieve(id);
        if (obj == null)
        {
            return NotFound();
        }

        var serializer = new IncomeTypeSerializer(obj);
        return new JsonResult(serializer);
    }

    [HttpPost]
    public async Task<ActionResult<IncomeType>> Create(IncomeTypeSerializer incomeTypeSerializer)
    {
        var incomeType = await _incomeTypeService.Create(incomeTypeSerializer.BuildInstance());
        return CreatedAtAction(nameof(Retrieve), new { id = incomeType.Id }, incomeType);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<IncomeType>> Update(int id, IncomeTypeSerializer serializer)
    {
        var obj = await _incomeTypeService.Retrieve(id);
        if (obj == null)
        {
            return NotFound();
        }
        obj = serializer.UpdateInstance(obj);
        await _incomeTypeService.Update(obj);
        return RedirectToAction(nameof(Retrieve), new { id = obj.Id });
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<IncomeType>> Delete(int id)
    {
        await _incomeTypeService.Delete(id);
        return Ok("ok");
    }
}