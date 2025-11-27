using Application.DTOs;

namespace Infrastructure.Interfaces;

public interface IForecastService
{
    Task<IEnumerable<ForecastDto>> GetAllAsync();
    Task<ForecastDto?> GetByIdAsync(long id);
    Task<ForecastDto> CreateAsync(ForecastDto forecastDto);
    Task<ForecastDto?> UpdateAsync(long id, ForecastDto forecastDto);
    Task<bool> DeleteAsync(long id);
}
