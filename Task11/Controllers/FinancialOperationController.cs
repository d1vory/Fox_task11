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
    public async Task<ActionResult<IEnumerable<FinancialOperation>>> List()
    {
        var objects = await _service.List();
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
    public async Task<ActionResult<FinancialOperation>> Update([FromRoute] int id, [FromBody] UpdateFinancialOperationDto operationDto)
    {
        var obj = await _service.Update(id, operationDto);
        if (obj == null)
        {
            return NotFound();
        }
        return Ok(obj);
    }
    
    // [HttpDelete("{id}")]
    // public async Task<ActionResult<FinancialOperation>> Delete(int id)
    // {
    //     await _service.Delete(id);
    //     return Ok("ok");
    // }
    //
    // [HttpGet("dailyReport")]
    // public async Task<ActionResult<IEnumerable<FinancialOperation>>> GetDailyReport(DateOnly date)
    // {
    //     var report = await _service.GetPeriodicReport(date.ToDateTime(TimeOnly.MinValue));
    //     var kek = new
    //     {
    //         report.TotalIncome,
    //         report.TotalExpense,
    //         Operations = FinancialOperationSerializer.SerializeList(report.Operations)
    //     };
    //     return Ok(kek);
    // }
    //
    // [HttpGet("periodicReport")]
    // public async Task<ActionResult<IEnumerable<FinancialOperation>>> GetPeriodicReport(DateOnly startDate, DateOnly endDate)
    // {
    //     var report = await _service.GetPeriodicReport(startDate.ToDateTime(TimeOnly.MinValue), endDate.ToDateTime(TimeOnly.MinValue));
    //     var kek = new
    //     {
    //         report.TotalIncome,
    //         report.TotalExpense,
    //         Operations = FinancialOperationSerializer.SerializeList(report.Operations)
    //     };
    //     return Ok(kek);
    // }
    
}