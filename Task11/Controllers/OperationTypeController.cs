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
        // var serializedObjects = ExpenseTypeSerializer.SerializeList(objects);
    }






}