using AdvAsmPlanning.Application;
using AdvAsmPlanning.Application.DTOs;

namespace AdvAsmPlanning.Infrastructure.Interfaces;

public interface IPlanningScenarioService
{
    Task<ApiResponseDto<IEnumerable<PlanningScenarioDto>>> GetAllAsync();
    Task<ApiResponseDto<PlanningScenarioDto>> GetByIdAsync(long id);
    Task<ApiResponseDto<PlanningScenarioDto>> CreateAsync(PlanningScenarioDto dto);
    Task<ApiResponseDto<PlanningScenarioDto>> UpdateAsync(PlanningScenarioDto dto);
    Task<ApiResponse> DeleteAsync(long id);
}
