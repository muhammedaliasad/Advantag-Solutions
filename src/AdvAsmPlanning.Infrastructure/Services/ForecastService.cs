using AdvAsmPlanning.Application;
using AdvAsmPlanning.Application.DTOs;
using AdvAsmPlanning.Domain.Database;
using AdvAsmPlanning.Domain.Entities;
using AdvAsmPlanning.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdvAsmPlanning.Infrastructure.Services;

public class ForecastService(ApplicationDbContext context, IMapper mapper) : IForecastService
{
    private readonly IMapper _mapper = mapper;

    public async Task<ApiResponseDto<IEnumerable<ForecastDto>>> GetAllAsync()
    {
        var forecasts = await context.Forecasts
            .Include(f => f.Actuals)
            .ToListAsync();

        var dtos = _mapper.Map<IEnumerable<ForecastDto>>(forecasts).ToList();
        return ApiResponseDto<IEnumerable<ForecastDto>>.SuccessResponse(dtos, dtos.LongCount());
    }

    public async Task<ApiResponseDto<ForecastDto>> GetByIdAsync(long id)
    {
        var forecast = await context.Forecasts
            .Include(f => f.Actuals)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (forecast == null)
            return ApiResponseDto<ForecastDto>.FailureResponse("Record not found.");

        return ApiResponseDto<ForecastDto>.SuccessResponse(_mapper.Map<ForecastDto>(forecast), 1);
    }

    public async Task<ApiResponseDto<ForecastDto>> CreateAsync(ForecastDto forecastDto)
    {
        var forecast = _mapper.Map<Forecast>(forecastDto);

        context.Forecasts.Add(forecast);
        await context.SaveChangesAsync();

        return ApiResponseDto<ForecastDto>.SuccessResponse(_mapper.Map<ForecastDto>(forecast), 1, message: "Record created successfully.");
    }

    public async Task<ApiResponseDto<ForecastDto>> UpdateAsync(ForecastDto forecastDto)
    {
        var forecast = await context.Forecasts
            .Include(f => f.Actuals)
            .FirstOrDefaultAsync(f => f.Id == forecastDto.Id);

        if (forecast == null)
            return ApiResponseDto<ForecastDto>.FailureResponse("Record not found.");

        // Map incoming DTO onto the tracked entity
        _mapper.Map(forecastDto, forecast);
        await context.SaveChangesAsync();

        return ApiResponseDto<ForecastDto>.SuccessResponse(_mapper.Map<ForecastDto>(forecast), 1, message: "Record updated successfully.");
    }

    public async Task<ApiResponse> DeleteAsync(long id)
    {
        var forecast = await context.Forecasts.FindAsync(id);

        if (forecast == null)
            return ApiResponse.FailureResponse("Record not found.");

        context.Forecasts.Remove(forecast);
        await context.SaveChangesAsync();

        return ApiResponse.SuccessResponse("Record deleted successfully.");
    }
}
