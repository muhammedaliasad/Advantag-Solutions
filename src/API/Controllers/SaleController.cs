using Application.DTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaleController : ControllerBase
{
    private readonly ISalesService _service;

    public SaleController(ISalesService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route(nameof(GetAllSales))]
    [Authorize]
    public async Task<ActionResult<IEnumerable<SaleDto>>> GetAllSales()
    {
        var stats = await _service.GetAllAsync();
        return Ok(stats);
    }
}
