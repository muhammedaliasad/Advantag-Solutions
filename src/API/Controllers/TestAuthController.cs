using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestAuthController(IAuthService authService) : ControllerBase
{
    [HttpGet("token/{userId:long}")]
    public ActionResult<string> GetToken(long userId, [FromQuery] string roles = "User")
    {
        var rolesList = roles.Split(',').Select(r => r.Trim()).Where(r => !string.IsNullOrEmpty(r));
        var token = authService.GenerateToken(userId, rolesList);
        return Ok(token);
    }
}
