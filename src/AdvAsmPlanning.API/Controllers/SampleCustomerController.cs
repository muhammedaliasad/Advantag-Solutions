using Microsoft.AspNetCore.Authorization;

namespace AdvAsmPlanning.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SampleCustomerController : ControllerBase
{
    [HttpPost("admin-only")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminOnly() => Ok("Hello Admin");

    [HttpPost("user-only")]
    [Authorize(Roles = "User")]
    public IActionResult UserOnly() => Ok("Hello User");
}
