using Microsoft.AspNetCore.Mvc;
using Task11.Models;
using Task11.Serializers;
using Task11.Services;

namespace Task11.Controllers;


[Route("api/operation")]
[ApiController]
public class FinancialOperationController: ControllerBase
{
    private readonly FinancialOperationService _service;

    public FinancialOperationController(FinancialOperationService service)
    {
        _service = service;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FinancialOperation>>> List()
    {
        var objects = await _service.List();
        var serializedObjects = new FinancialOperationSerializer[objects.Count];
        for (int i = 0; i < objects.Count; i++)
        {
            serializedObjects[i] = new FinancialOperationSerializer(objects[i]);
        }
        return Ok(serializedObjects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FinancialOperation>> Retrieve(int id)
    {
        var obj = await _service.Retrieve(id);
        if (obj == null)
        {
            return NotFound();
        }

        var serializer = new FinancialOperationSerializer(obj);
        return new JsonResult(serializer);
    }

    [HttpPost]
    public async Task<ActionResult<FinancialOperation>> Create(FinancialOperationSerializer serializer)
    {
        var obj = await _service.Create(serializer.BuildInstance());
        return CreatedAtAction(nameof(Retrieve), new { id = obj.Id }, new FinancialOperationSerializer(obj));
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<FinancialOperation>> Update(int id, FinancialOperationSerializer serializer)
    {
        var obj = await _service.Retrieve(id);
        if (obj == null)
        {
            return NotFound();
        }
        obj = serializer.UpdateInstance(obj);
        await _service.Update(obj);
        return RedirectToAction(nameof(Retrieve), new { id = obj.Id });
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<FinancialOperation>> Delete(int id)
    {
        await _service.Delete(id);
        return Ok("ok");
    }
    
}