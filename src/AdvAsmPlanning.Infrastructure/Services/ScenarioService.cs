namespace AdvAsmPlanning.Infrastructure.Services;

public class ScenarioService(ApplicationDbContext context, IMapper mapper) : IScenarioService
{
    private readonly IMapper _mapper = mapper;

    public async Task<ApiResponseDto<IEnumerable<ScenarioDto>>> GetAllAsync()
    {
        var scenarios = await context.Scenarios
            .OrderBy(s => s.Code)
            .ToListAsync();

        var dtos = _mapper.Map<IEnumerable<ScenarioDto>>(scenarios).ToList();
        return ApiResponseDto<IEnumerable<ScenarioDto>>.SuccessResponse(dtos, dtos.LongCount());
    }

    public async Task<ApiResponseDto<ScenarioDto>> GetByIdAsync(long id)
    {
        var scenario = await context.Scenarios
            .FirstOrDefaultAsync(s => s.Id == id);

        if (scenario == null)
            return ApiResponseDto<ScenarioDto>.FailureResponse("Scenario not found.");

        return ApiResponseDto<ScenarioDto>.SuccessResponse(_mapper.Map<ScenarioDto>(scenario), 1);
    }

    public async Task<ApiResponseDto<ScenarioDto>> CreateAsync(ScenarioDto dto)
    {
        var scenario = _mapper.Map<Scenario>(dto);
        scenario.CreatedAt = DateTime.UtcNow;

        context.Scenarios.Add(scenario);
        await context.SaveChangesAsync();

        return ApiResponseDto<ScenarioDto>.SuccessResponse(
            _mapper.Map<ScenarioDto>(scenario),
            1,
            "Scenario created successfully.");
    }

    public async Task<ApiResponseDto<ScenarioDto>> UpdateAsync(ScenarioDto dto)
    {
        var scenario = await context.Scenarios
            .FirstOrDefaultAsync(s => s.Id == dto.Id);

        if (scenario == null)
            return ApiResponseDto<ScenarioDto>.FailureResponse("Scenario not found.");

        _mapper.Map(dto, scenario);
        scenario.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync();

        return ApiResponseDto<ScenarioDto>.SuccessResponse(
            _mapper.Map<ScenarioDto>(scenario),
            1,
            "Scenario updated successfully.");
    }

    public async Task<ApiResponse> DeleteAsync(long id)
    {
        var scenario = await context.Scenarios.FindAsync(id);

        if (scenario == null)
            return ApiResponse.FailureResponse("Scenario not found.");

        context.Scenarios.Remove(scenario);
        await context.SaveChangesAsync();

        return ApiResponse.SuccessResponse("Scenario deleted successfully.");
    }
}
