using AdvAsmPlanning.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvAsmPlanning.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("token")]
    public ActionResult<string> GetToken()
    {
        long userId = 1002;
        string[] roles = ["Admin"];

        var token = authService.GenerateToken(userId, roles);
        return Ok(token);
    }
}
