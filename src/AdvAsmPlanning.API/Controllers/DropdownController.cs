namespace AdvAsmPlanning.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DropdownController(IDropdownService dropdownService) : ControllerBase
{
    [ProducesResponseType(typeof(ApiResponseDto<IEnumerable<DropdownResponseDto>>), 200)]
    public async Task<IActionResult> GetDropdown([FromQuery] DropdownKey key)
        => Ok(await dropdownService.GetAllAsync(key));
}