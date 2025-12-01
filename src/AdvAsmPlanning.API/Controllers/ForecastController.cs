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
    {
        var forecasts = await forecastService.GetAllAsync();
        var result = ApiResponseDto<IEnumerable<ForecastDto>>.SuccessResponse(forecasts, forecasts.LongCount());
        return Ok(result);
    }

    [HttpPost(nameof(GetById))]
    public async Task<ActionResult<ApiResponseDto<ForecastDto>>> GetById([FromBody] long id)
    {
        var forecast = await forecastService.GetByIdAsync(id);

        if (forecast == null)
            return NotFound(ApiResponse.FailureResponse("Forecast not found"));

        return Ok(ApiResponseDto<ForecastDto>.SuccessResponse(forecast, 1));
    }

    [HttpPost(nameof(Create))]
    public async Task<ActionResult<ApiResponseDto<ForecastDto>>> Create([FromBody] ForecastDto forecastDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ApiResponse.FailureResponse("Invalid model state"));

        var created = await forecastService.CreateAsync(forecastDto);
        var result = ApiResponseDto<ForecastDto>.SuccessResponse(created, 1);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, result);
    }

    [HttpPost(nameof(Update))]
    public async Task<ActionResult<ApiResponseDto<ForecastDto>>> Update([FromBody] ForecastDto forecastDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ApiResponse.FailureResponse("Invalid model state"));

        var updated = await forecastService.UpdateAsync(forecastDto);

        if (updated == null)
            return NotFound(ApiResponse.FailureResponse("Forecast not found"));

        return Ok(ApiResponseDto<ForecastDto>.SuccessResponse(updated, 1));
    }

    [HttpPost(nameof(Delete))]
    public async Task<ActionResult<ApiResponse>> Delete([FromBody] long id)
    {
        var deleted = await forecastService.DeleteAsync(id);

        if (!deleted)
            return NotFound(ApiResponse.FailureResponse("Forecast not found"));

        return Ok(ApiResponse.SuccessResponse("Forecast deleted", totalRecords: 0));
    }
}
