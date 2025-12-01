using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    [HttpPost("admin-only")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminOnly() => Ok("Hello Admin");

    [HttpPost("user-only")]
    [Authorize(Roles = "User")]
    public IActionResult UserOnly() => Ok("Hello User");
}
