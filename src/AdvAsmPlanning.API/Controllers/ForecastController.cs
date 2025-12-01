using AdvAsmPlanning.Application;
using AdvAsmPlanning.Application.DTOs;
using AdvAsmPlanning.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvAsmPlanning.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ForecastController(IForecastService forecastService) : ControllerBase
{
    [HttpPost(nameof(GetAll))]
    public async Task<ActionResult<ApiResponseDto<IEnumerable<ForecastDto>>>> GetAll()
        => Ok(await forecastService.GetAllAsync());

    [HttpPost(nameof(GetById))]
    public async Task<ActionResult<ApiResponseDto<ForecastDto>>> GetById([FromBody] long id)
        => Ok(await forecastService.GetByIdAsync(id));

    [HttpPost(nameof(Create))]
    public async Task<ActionResult<ApiResponseDto<ForecastDto>>> Create([FromBody] ForecastDto forecastDto)
        => await forecastService.CreateAsync(forecastDto);

    [HttpPost(nameof(Update))]
    public async Task<ActionResult<ApiResponseDto<ForecastDto>>> Update([FromBody] ForecastDto forecastDto)
        => await forecastService.UpdateAsync(forecastDto);

    [HttpPost(nameof(Delete))]
    public async Task<ActionResult<ApiResponse>> Delete([FromBody] long id)
        => Ok(await forecastService.DeleteAsync(id));
}
