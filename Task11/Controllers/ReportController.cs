using Microsoft.AspNetCore.Mvc;
using Shared2.DTO.Reports;
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
    
    [HttpGet("operations")]
    public async Task<ActionResult<FinOpReportDto>> GetPeriodicReport([FromQuery] DateTime startDate, [FromQuery] DateTime? endDate=null)
    {
        var report = await _service.GetPeriodicReport(startDate, endDate);
        return Ok(report);
    }
}