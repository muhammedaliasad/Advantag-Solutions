using AdvAsmPlanning.Application;
using AdvAsmPlanning.Application.DTOs;
using AdvAsmPlanning.Domain.Database;
using AdvAsmPlanning.Domain.Entities;
using AdvAsmPlanning.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdvAsmPlanning.Infrastructure.Services;

public class PlanningScenarioService(ApplicationDbContext context, IMapper mapper) : IPlanningScenarioService
{
    private readonly IMapper _mapper = mapper;

    public async Task<ApiResponseDto<IEnumerable<PlanningScenarioDto>>> GetAllAsync()
    {
        var scenarios = await context.PlanningScenarios
            .OrderBy(s => s.Code)
            .ToListAsync();

        var dtos = _mapper.Map<IEnumerable<PlanningScenarioDto>>(scenarios).ToList();
        return ApiResponseDto<IEnumerable<PlanningScenarioDto>>.SuccessResponse(dtos, dtos.LongCount());
    }

    public async Task<ApiResponseDto<PlanningScenarioDto>> GetByIdAsync(long id)
    {
        var scenario = await context.PlanningScenarios
            .FirstOrDefaultAsync(s => s.Id == id);

        if (scenario == null)
            return ApiResponseDto<PlanningScenarioDto>.FailureResponse("Planning Scenario not found.");

        return ApiResponseDto<PlanningScenarioDto>.SuccessResponse(_mapper.Map<PlanningScenarioDto>(scenario), 1);
    }

    public async Task<ApiResponseDto<PlanningScenarioDto>> CreateAsync(PlanningScenarioDto dto)
    {
        var scenario = _mapper.Map<PlanningScenario>(dto);
        scenario.CreatedAt = DateTime.UtcNow;

        context.PlanningScenarios.Add(scenario);
        await context.SaveChangesAsync();

        return ApiResponseDto<PlanningScenarioDto>.SuccessResponse(
            _mapper.Map<PlanningScenarioDto>(scenario), 
            1, 
            "Planning Scenario created successfully.");
    }

    public async Task<ApiResponseDto<PlanningScenarioDto>> UpdateAsync(PlanningScenarioDto dto)
    {
        var scenario = await context.PlanningScenarios
            .FirstOrDefaultAsync(s => s.Id == dto.Id);

        if (scenario == null)
            return ApiResponseDto<PlanningScenarioDto>.FailureResponse("Planning Scenario not found.");

        _mapper.Map(dto, scenario);
        scenario.UpdatedAt = DateTime.UtcNow;
        
        await context.SaveChangesAsync();

        return ApiResponseDto<PlanningScenarioDto>.SuccessResponse(
            _mapper.Map<PlanningScenarioDto>(scenario), 
            1, 
            "Planning Scenario updated successfully.");
    }

    public async Task<ApiResponse> DeleteAsync(long id)
    {
        var scenario = await context.PlanningScenarios.FindAsync(id);

        if (scenario == null)
            return ApiResponse.FailureResponse("Planning Scenario not found.");

        context.PlanningScenarios.Remove(scenario);
        await context.SaveChangesAsync();

        return ApiResponse.SuccessResponse("Planning Scenario deleted successfully.");
    }
}
