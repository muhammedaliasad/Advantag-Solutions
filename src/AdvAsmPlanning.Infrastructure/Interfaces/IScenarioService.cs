namespace AdvAsmPlanning.Infrastructure.Interfaces;

public interface IScenarioService
{
    Task<ApiResponseDto<IEnumerable<ScenarioDto>>> GetAllAsync();
    Task<ApiResponseDto<ScenarioDto>> GetByIdAsync(long id);
    Task<ApiResponseDto<ScenarioDto>> CreateAsync(ScenarioDto dto);
    Task<ApiResponseDto<ScenarioDto>> UpdateAsync(ScenarioDto dto);
    Task<ApiResponse> DeleteAsync(long id);
}
