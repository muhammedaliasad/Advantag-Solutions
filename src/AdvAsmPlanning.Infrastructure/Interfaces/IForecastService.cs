namespace AdvAsmPlanning.Infrastructure.Interfaces;

public interface IForecastService
{
    Task<ApiResponseDto<IEnumerable<ForecastDto>>> GetAllAsync();
    Task<ApiResponseDto<ForecastDto>> GetByIdAsync(long id);
    Task<ApiResponseDto<ForecastDto>> CreateAsync(ForecastDto forecastDto);
    Task<ApiResponseDto<ForecastDto>> UpdateAsync(ForecastDto forecastDto);
    Task<ApiResponse> DeleteAsync(long id);
}
