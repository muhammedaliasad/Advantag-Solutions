using CleanArch.Application.DTOs;
using CleanArch.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesStatsController(SalesStatsService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SalesStatDto>>> Get()
    {
        var stats = await service.GetSalesStatsAsync();
        return Ok(stats);
    }
}
