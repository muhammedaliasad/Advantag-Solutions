using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    [HttpGet("admin-only")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminOnly() => Ok("Hello Admin");

    [HttpGet("user-only")]
    [Authorize(Roles = "User")]
    public IActionResult UserOnly() => Ok("Hello User");
}
