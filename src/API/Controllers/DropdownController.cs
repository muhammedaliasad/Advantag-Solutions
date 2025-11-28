using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("api/[controller]")]
public class DropdownController(IDropdownService service) : ControllerBase
{
    // POST api/Dropdown/get-all
    [HttpPost("get-all")]
    public async Task<ActionResult<IEnumerable<Dropdown>>> GetAll([Required][FromBody] string key)
    {
        var list = await service.GetAllAsync(key);
        return Ok(list);
    }

    // POST api/Dropdown/get
    [HttpPost("get")]
    public async Task<ActionResult<Dropdown>> Get([FromBody] long id)
    {
        var dto = await service.GetByIdAsync(id);
        if (dto is null) return NotFound();
        return Ok(dto);
    }

    // POST api/Dropdown/create
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] Dropdown dto)
    {
        await service.AddAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }

    // PUT api/Dropdown/5
    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] Dropdown dto)
    {
        if (id != dto.Id) return BadRequest();
        await service.UpdateAsync(dto);
        return NoContent();
    }

    // DELETE api/Dropdown/5
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        await service.RemoveAsync(id);
        return NoContent();
    }
}
