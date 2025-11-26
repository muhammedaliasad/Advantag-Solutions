using Application.DTOs;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaleController(SalesService service) : ControllerBase
{
    [HttpPost]
    [Route(nameof(GetAllSales))]
    public async Task<ActionResult<IEnumerable<SaleDto>>> GetAllSales()
    {
        var stats = await service.GetAllAsync();
        return Ok(stats);
    }
}
