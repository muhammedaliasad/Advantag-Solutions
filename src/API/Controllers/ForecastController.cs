using Application.DTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ForecastController(IForecastService forecastService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ForecastDto>>> GetAll()
    {
        var forecasts = await forecastService.GetAllAsync();
        return Ok(forecasts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ForecastDto>> GetById(long id)
    {
        var forecast = await forecastService.GetByIdAsync(id);

        if (forecast == null)
            return NotFound();

        return Ok(forecast);
    }

    [HttpPost]
    public async Task<ActionResult<ForecastDto>> Create([FromBody] ForecastDto forecastDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await forecastService.CreateAsync(forecastDto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ForecastDto>> Update(long id, [FromBody] ForecastDto forecastDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await forecastService.UpdateAsync(id, forecastDto);

        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        var deleted = await forecastService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
