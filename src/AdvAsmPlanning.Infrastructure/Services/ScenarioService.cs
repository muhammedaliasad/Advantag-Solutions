namespace AdvAsmPlanning.Infrastructure.Services;

public class ScenarioService(ApplicationDbContext context, IMapper mapper, ILogger<ScenarioService> logger) : IScenarioService
{
    private readonly IMapper _mapper = mapper;

    public async Task<ApiResponseDto<IEnumerable<ScenarioDto>>> GetAllAsync()
    {
        try
        {
            var scenarios = await context.Scenarios
                .OrderBy(s => s.Code)
                .ToListAsync();

            var dtos = _mapper.Map<IEnumerable<ScenarioDto>>(scenarios).ToList();
            return ApiResponseDto<IEnumerable<ScenarioDto>>.SuccessResponse(dtos, dtos.LongCount());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while retrieving scenarios");
            return ApiResponseDto<IEnumerable<ScenarioDto>>.FailureResponse($"An error occurred while retrieving scenarios: {ex.Message}");
        }
    }

    public async Task<ApiResponseDto<ScenarioDto>> GetByIdAsync(long id)
    {
        try
        {
            var scenario = await context.Scenarios
                .FirstOrDefaultAsync(s => s.Id == id);

            if (scenario == null)
                return ApiResponseDto<ScenarioDto>.FailureResponse("Scenario not found.");

            return ApiResponseDto<ScenarioDto>.SuccessResponse(_mapper.Map<ScenarioDto>(scenario), 1);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while retrieving scenario with Id: {Id}", id);
            return ApiResponseDto<ScenarioDto>.FailureResponse($"An error occurred while retrieving scenario: {ex.Message}");
        }
    }

    public async Task<ApiResponseDto<ScenarioDto>> CreateAsync(ScenarioDto dto)
    {
        try
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
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while creating scenario");
            return ApiResponseDto<ScenarioDto>.FailureResponse($"An error occurred while creating scenario: {ex.Message}");
        }
    }

    public async Task<ApiResponseDto<ScenarioDto>> UpdateAsync(ScenarioDto dto)
    {
        try
        {
            // Validate Id using generic validator
            var validationResult = DtoValidator.ValidateIdWithResponse<ScenarioDto>(dto.Id, logger, "Scenario");
            if (validationResult != null)
                return validationResult;

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
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while updating scenario with Id: {Id}", dto.Id);
            return ApiResponseDto<ScenarioDto>.FailureResponse($"An error occurred while updating scenario: {ex.Message}");
        }
    }

    public async Task<ApiResponse> DeleteAsync(long id)
    {
        try
        {
            var scenario = await context.Scenarios.FindAsync(id);

            if (scenario == null)
                return ApiResponse.FailureResponse("Scenario not found.");

            context.Scenarios.Remove(scenario);
            await context.SaveChangesAsync();

            return ApiResponse.SuccessResponse("Scenario deleted successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while deleting scenario with Id: {Id}", id);
            return ApiResponse.FailureResponse($"An error occurred while deleting scenario: {ex.Message}");
        }
    }
}
