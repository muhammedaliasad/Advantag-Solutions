namespace AdvAsmPlanning.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SampleAuthController(IAuthService authService) : ControllerBase
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
