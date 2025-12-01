using AdvAsmPlanning.Domain.Entities;
using AdvAsmPlanning.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AdvAsmPlanning.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DropdownController(IDropdownService service) : ControllerBase
{
    [HttpPost("GetAll")]
    public async Task<ActionResult<IEnumerable<Dropdown>>> GetAll([Required][FromBody] string key)
    {
        var list = await service.GetAllAsync(key);
        return Ok(list);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<Dropdown>> Get(long id)
    {
        var dto = await service.GetByIdAsync(id);
        if (dto is null) return NotFound();
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Dropdown dto)
    {
        await service.AddAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, Dropdown dto)
    {
        if (id != dto.Id) return BadRequest();
        await service.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        await service.RemoveAsync(id);
        return NoContent();
    }
}
