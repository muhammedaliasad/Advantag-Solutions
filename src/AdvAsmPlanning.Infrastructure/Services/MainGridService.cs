namespace AdvAsmPlanning.Infrastructure.Services;

public class MainGridService(ApplicationDbContext context, IMapper mapper, ILogger<MainGridService> logger) : IMainGridService
{
    private readonly IMapper _mapper = mapper;

    public async Task<ApiResponseDto<IEnumerable<MainGridDto>>> GetAllAsync()
    {
        try
        {
            var mainGrids = await context.MainGrids
                .Include(f => f.Actuals)
                .ToListAsync();

            var dtos = _mapper.Map<IEnumerable<MainGridDto>>(mainGrids).ToList();
            return ApiResponseDto<IEnumerable<MainGridDto>>.SuccessResponse(dtos, dtos.LongCount());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while retrieving main grids");
            return ApiResponseDto<IEnumerable<MainGridDto>>.FailureResponse($"An error occurred while retrieving main grids: {ex.Message}");
        }
    }

    public async Task<ApiResponseDto<MainGridDto>> GetByIdAsync(long id)
    {
        try
        {
            var mainGrid = await context.MainGrids
                .Include(f => f.Actuals)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (mainGrid == null)
                return ApiResponseDto<MainGridDto>.FailureResponse("Record not found.");

            return ApiResponseDto<MainGridDto>.SuccessResponse(_mapper.Map<MainGridDto>(mainGrid), 1);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while retrieving main grid with Id: {Id}", id);
            return ApiResponseDto<MainGridDto>.FailureResponse($"An error occurred while retrieving main grid: {ex.Message}");
        }
    }

    public async Task<ApiResponseDto<MainGridDto>> CreateAsync(MainGridDto mainGridDto)
    {
        try
        {
            var mainGrid = _mapper.Map<MainGrid>(mainGridDto);

            context.MainGrids.Add(mainGrid);
            await context.SaveChangesAsync();

            return ApiResponseDto<MainGridDto>.SuccessResponse(_mapper.Map<MainGridDto>(mainGrid), 1, message: "Record created successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while creating main grid");
            return ApiResponseDto<MainGridDto>.FailureResponse($"An error occurred while creating main grid: {ex.Message}");
        }
    }

    public async Task<ApiResponseDto<MainGridDto>> UpdateAsync(MainGridDto mainGridDto)
    {
        try
        {
            // Validate Id using generic validator
            var validationResult = DtoValidator.ValidateIdWithResponse<MainGridDto>(mainGridDto.Id, logger, "MainGrid");
            if (validationResult is not null)
                return validationResult;

            var mainGrid = await context.MainGrids
                .Include(f => f.Actuals)
                .FirstOrDefaultAsync(f => f.Id == mainGridDto.Id);

            if (mainGrid == null)
                return ApiResponseDto<MainGridDto>.FailureResponse("Record not found.");

            // Map incoming DTO onto the tracked entity
            _mapper.Map(mainGridDto, mainGrid);
            await context.SaveChangesAsync();

            return ApiResponseDto<MainGridDto>.SuccessResponse(_mapper.Map<MainGridDto>(mainGrid), 1, message: "Record updated successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while updating main grid with Id: {Id}", mainGridDto.Id);
            return ApiResponseDto<MainGridDto>.FailureResponse($"An error occurred while updating main grid: {ex.Message}");
        }
    }

    public async Task<ApiResponse> DeleteAsync(long id)
    {
        try
        {
            var mainGrid = await context.MainGrids.FindAsync(id);

            if (mainGrid == null)
                return ApiResponse.FailureResponse("Record not found.");

            context.MainGrids.Remove(mainGrid);
            await context.SaveChangesAsync();

            return ApiResponse.SuccessResponse("Record deleted successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while deleting main grid with Id: {Id}", id);
            return ApiResponse.FailureResponse($"An error occurred while deleting main grid: {ex.Message}");
        }
    }
}
