using AdvAsmPlanning.Application.DTOs;

namespace AdvAsmPlanning.Infrastructure.Interfaces;

public interface IForecastService
{
    Task<IEnumerable<ForecastDto>> GetAllAsync();
    Task<ForecastDto?> GetByIdAsync(long id);
    Task<ForecastDto> CreateAsync(ForecastDto forecastDto);
    Task<ForecastDto?> UpdateAsync(ForecastDto forecastDto);
    Task<bool> DeleteAsync(long id);
}
