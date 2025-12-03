namespace AdvAsmPlanning.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScenarioController(IScenarioService scenarioService) : ControllerBase
{
    [HttpPost(nameof(GetAll))]
    public async Task<ActionResult<ApiResponseDto<IEnumerable<ScenarioDto>>>> GetAll()
        => Ok(await scenarioService.GetAllAsync());

    [HttpPost(nameof(GetById))]
    public async Task<ActionResult<ApiResponseDto<ScenarioDto>>> GetById([FromBody] long id)
        => Ok(await scenarioService.GetByIdAsync(id));

    [HttpPost(nameof(Create))]
    public async Task<ActionResult<ApiResponseDto<ScenarioDto>>> Create([FromBody] ScenarioDto dto)
        => await scenarioService.CreateAsync(dto);

    [HttpPost(nameof(Update))]
    public async Task<ActionResult<ApiResponseDto<ScenarioDto>>> Update([FromBody] ScenarioDto dto)
        => await scenarioService.UpdateAsync(dto);

    [HttpPost(nameof(Delete))]
    public async Task<ActionResult<ApiResponse>> Delete([FromBody] long id)
        => Ok(await scenarioService.DeleteAsync(id));
}
