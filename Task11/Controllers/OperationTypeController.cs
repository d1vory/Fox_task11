using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Task11.DTO.OperationType;
using Task11.Models;
using Task11.Services;

namespace Task11.Controllers;

[Route("api/operation_type")]
[ApiController]
public class OperationTypeController: ControllerBase
{
    private readonly OperationTypeService _typeService;
    
    public OperationTypeController(OperationTypeService typeService)
    {
        _typeService = typeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OperationTypeDto>>> List()
    {
        
        var objects = await _typeService.List();
        return Ok(objects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OperationTypeDto>> Retrieve([FromRoute] int id)
    {
        var obj = await _typeService.Retrieve(id);
        if (obj == null)
        {
            return NotFound();
        }

        return Ok(obj);
    }
    
    [HttpPost]
    public async Task<ActionResult<OperationTypeDto>> Create([FromBody] CreateOperationTypeDto operationTypeDto)
    {
        var obj = await _typeService.Create(operationTypeDto);
        return Ok(obj);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<OperationTypeDto>> Update([FromRoute] int id, [FromBody] UpdateOperationTypeDto operationTypeDto)
    {
        var obj = await _typeService.Update(id, operationTypeDto);
        return Ok(obj);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        {
            try
            {
                var isDeleted = await _typeService.Delete(id);
                if (!isDeleted)
                {
                    return NotFound();
                }
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
    
}