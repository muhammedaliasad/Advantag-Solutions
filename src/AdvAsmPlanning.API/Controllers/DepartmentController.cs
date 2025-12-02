using AdvAsmPlanning.Application.DTOs;
using AdvAsmPlanning.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvAsmPlanning.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController(IDepartmentService departmentService) : ControllerBase
{
    [HttpPost("dropdown")]
    public async Task<ActionResult<IEnumerable<DropdownDto>>> GetDropdown([FromBody] string key)
        => Ok(await departmentService.GetAllAsync(key));
}
