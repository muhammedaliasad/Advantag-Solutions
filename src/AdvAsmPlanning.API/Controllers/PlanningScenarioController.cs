namespace AdvAsmPlanning.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlanningScenarioController(IPlanningScenarioService planningScenarioService) : ControllerBase
{
    [HttpPost(nameof(GetAll))]
    public async Task<ActionResult<ApiResponseDto<IEnumerable<PlanningScenarioDto>>>> GetAll()
        => Ok(await planningScenarioService.GetAllAsync());

    [HttpPost(nameof(GetById))]
    public async Task<ActionResult<ApiResponseDto<PlanningScenarioDto>>> GetById([FromBody] long id)
        => Ok(await planningScenarioService.GetByIdAsync(id));

    [HttpPost(nameof(Create))]
    public async Task<ActionResult<ApiResponseDto<PlanningScenarioDto>>> Create([FromBody] PlanningScenarioDto dto)
        => await planningScenarioService.CreateAsync(dto);

    [HttpPost(nameof(Update))]
    public async Task<ActionResult<ApiResponseDto<PlanningScenarioDto>>> Update([FromBody] PlanningScenarioDto dto)
        => await planningScenarioService.UpdateAsync(dto);

    [HttpPost(nameof(Delete))]
    public async Task<ActionResult<ApiResponse>> Delete([FromBody] long id)
        => Ok(await planningScenarioService.DeleteAsync(id));
}
