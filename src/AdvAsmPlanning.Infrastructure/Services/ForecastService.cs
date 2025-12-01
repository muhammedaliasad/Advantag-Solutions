using AdvAsmPlanning.Application.DTOs;
using AdvAsmPlanning.Domain.Database;
using AdvAsmPlanning.Domain.Entities;
using AdvAsmPlanning.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdvAsmPlanning.Infrastructure.Services;

public class ForecastService(ApplicationDbContext context) : IForecastService
{
    public async Task<IEnumerable<ForecastDto>> GetAllAsync()
    {
        var forecasts = await context.Forecasts
            .Include(f => f.Actuals)
            .ToListAsync();

        return forecasts.Select(MapToDto);
    }

    public async Task<ForecastDto?> GetByIdAsync(long id)
    {
        var forecast = await context.Forecasts
            .Include(f => f.Actuals)
            .FirstOrDefaultAsync(f => f.Id == id);

        return forecast == null ? null : MapToDto(forecast);
    }

    public async Task<ForecastDto> CreateAsync(ForecastDto forecastDto)
    {
        var forecast = new Forecast
        {
            Client = forecastDto.Client,
            Customer = forecastDto.Customer,
            SizeProject = forecastDto.SizeProject,
            Project = forecastDto.Project,
            GoFind = forecastDto.GoFind,
            Comment = forecastDto.Comment,
            Delta = forecastDto.Delta,
            AccountNo = forecastDto.AccountNo,
            DepartmentNo = forecastDto.DepartmentNo
        };

        // Add actuals
        foreach (var actualDto in forecastDto.Actuals)
        {
            forecast.Actuals.Add(new ForecastActual
            {
                Year = actualDto.Year,
                Month = actualDto.Month,
                Amount = actualDto.Amount
            });
        }

        context.Forecasts.Add(forecast);
        await context.SaveChangesAsync();

        return MapToDto(forecast);
    }

    public async Task<ForecastDto?> UpdateAsync(ForecastDto forecastDto)
    {
        var forecast = await context.Forecasts
            .Include(f => f.Actuals)
            .FirstOrDefaultAsync(f => f.Id == forecastDto.Id);

        if (forecast == null)
            return null;

        // Update properties
        forecast.Client = forecastDto.Client;
        forecast.Customer = forecastDto.Customer;
        forecast.SizeProject = forecastDto.SizeProject;
        forecast.Project = forecastDto.Project;
        forecast.GoFind = forecastDto.GoFind;
        forecast.Comment = forecastDto.Comment;
        forecast.Delta = forecastDto.Delta;
        forecast.AccountNo = forecastDto.AccountNo;
        forecast.DepartmentNo = forecastDto.DepartmentNo;
        forecast.UpdatedAt = DateTime.UtcNow;

        // Update actuals (simple approach: remove all and add new)
        context.ForecastActuals.RemoveRange(forecast.Actuals);

        foreach (var actualDto in forecastDto.Actuals)
        {
            forecast.Actuals.Add(new ForecastActual
            {
                Year = actualDto.Year,
                Month = actualDto.Month,
                Amount = actualDto.Amount,
                ForecastId = forecast.Id
            });
        }

        await context.SaveChangesAsync();

        return MapToDto(forecast);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var forecast = await context.Forecasts.FindAsync(id);

        if (forecast == null)
            return false;

        context.Forecasts.Remove(forecast);
        await context.SaveChangesAsync();

        return true;
    }

    private static ForecastDto MapToDto(Forecast forecast)
    {
        return new ForecastDto
        {
            Id = forecast.Id,
            Client = forecast.Client,
            Customer = forecast.Customer,
            SizeProject = forecast.SizeProject,
            Project = forecast.Project,
            GoFind = forecast.GoFind,
            Comment = forecast.Comment,
            Delta = forecast.Delta,
            AccountNo = forecast.AccountNo,
            DepartmentNo = forecast.DepartmentNo,
            Actuals = forecast.Actuals.Select(a => new ForecastActualDto
            {
                Id = a.Id,
                Year = a.Year,
                Month = a.Month,
                Amount = a.Amount
            }).ToList()
        };
    }
}
