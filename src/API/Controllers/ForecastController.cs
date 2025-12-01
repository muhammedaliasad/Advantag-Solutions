using Application.DTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ForecastController : ControllerBase
{
    private readonly IForecastService _forecastService;

    public ForecastController(IForecastService forecastService)
    {
        _forecastService = forecastService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ForecastDto>>> GetAll()
    {
        var forecasts = await _forecastService.GetAllAsync();
        return Ok(forecasts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ForecastDto>> GetById(long id)
    {
        var forecast = await _forecastService.GetByIdAsync(id);
        
        if (forecast == null)
            return NotFound();

        return Ok(forecast);
    }

    [HttpPost]
    public async Task<ActionResult<ForecastDto>> Create([FromBody] ForecastDto forecastDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _forecastService.CreateAsync(forecastDto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ForecastDto>> Update(long id, [FromBody] ForecastDto forecastDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _forecastService.UpdateAsync(id, forecastDto);
        
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        var deleted = await _forecastService.DeleteAsync(id);
        
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
