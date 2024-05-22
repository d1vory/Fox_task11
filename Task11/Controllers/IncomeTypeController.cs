using Microsoft.AspNetCore.Mvc;
using Task11.Data;
using Task11.Models;
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
        // var db = new ApplicationContext();
        // var kek = db.IncomeTypes.ToList();
        return Ok(await _incomeTypeService.List());
    }
    
    
}