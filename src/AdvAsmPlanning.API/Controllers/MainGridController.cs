namespace AdvAsmPlanning.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MainGridController(IMainGridService mainGridService) : ControllerBase
{
    [HttpPost(nameof(GetAll))]
    public async Task<ActionResult<ApiResponseDto<IEnumerable<MainGridDto>>>> GetAll()
        => Ok(await mainGridService.GetAllAsync());

    [HttpPost(nameof(GetById))]
    public async Task<ActionResult<ApiResponseDto<MainGridDto>>> GetById([FromBody] long id)
        => Ok(await mainGridService.GetByIdAsync(id));

    [HttpPost(nameof(Create))]
    public async Task<ActionResult<ApiResponseDto<MainGridDto>>> Create([FromBody] MainGridDto mainGridDto)
        => await mainGridService.CreateAsync(mainGridDto);

    [HttpPost(nameof(Update))]
    public async Task<ActionResult<ApiResponseDto<MainGridDto>>> Update([FromBody] MainGridDto mainGridDto)
        => await mainGridService.UpdateAsync(mainGridDto);

    [HttpPost(nameof(Delete))]
    public async Task<ActionResult<ApiResponse>> Delete([FromBody] long id)
        => Ok(await mainGridService.DeleteAsync(id));
}
