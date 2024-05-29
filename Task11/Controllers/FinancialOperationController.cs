using Microsoft.AspNetCore.Mvc;
using Task11.DTO.FinancialOperation;
using Task11.Models;
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
    public async Task<ActionResult<IEnumerable<FinancialOperationDto>>> List([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
    {
        var objects = await _service.List(startDate, endDate);
        return Ok(objects);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<FinancialOperationDto>> Retrieve([FromRoute] int id)
    {
        var obj = await _service.Retrieve(id);
        if (obj == null)
        {
            return NotFound();
        }

        return Ok(obj);
    }
    
    [HttpPost]
    public async Task<ActionResult<FinancialOperationDto>> Create([FromBody] CreateFinancialOperationDto operationDto)
    {
        var obj = await _service.Create(operationDto);
        return Ok(obj);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<FinancialOperationDto>> Update([FromRoute] int id, [FromBody] UpdateFinancialOperationDto operationDto)
    {
        var obj = await _service.Update(id, operationDto);
        if (obj == null)
        {
            return NotFound();
        }
        return Ok(obj);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var isDeleted = await _service.Delete(id);
        if (!isDeleted)
        {
            return NotFound();
        }
        return Ok();
    }
    
}