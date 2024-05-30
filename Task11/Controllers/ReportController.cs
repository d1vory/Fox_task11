using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Reports;
using Task11.Services;

namespace Task11.Controllers;

[Route("api/reports")]
[ApiController]
public class ReportController: ControllerBase
{
    private readonly ReportService _service;

    public ReportController(ReportService service)
    {
        _service = service;
    }
    
    
    [HttpGet("daily")]
    public async Task<ActionResult<FinOpReportDto>> GetDailyReport([FromQuery] DateTime date)
    {
        var report = await _service.GetDailyReport(date);
        return Ok(report);
    }
    
    [HttpGet("periodic")]
    public async Task<ActionResult<FinOpReportDto>> GetPeriodicReport([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var report = await _service.GetPeriodicReport(startDate, endDate);
        return Ok(report);
    }
}