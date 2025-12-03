namespace AdvAsmPlanning.Infrastructure.Services;

public class MainGridService(ApplicationDbContext context, IMapper mapper) : IMainGridService
{
    private readonly IMapper _mapper = mapper;

    public async Task<ApiResponseDto<IEnumerable<MainGridDto>>> GetAllAsync()
    {
        var mainGrids = await context.MainGrids
            .Include(f => f.Actuals)
            .ToListAsync();

        var dtos = _mapper.Map<IEnumerable<MainGridDto>>(mainGrids).ToList();
        return ApiResponseDto<IEnumerable<MainGridDto>>.SuccessResponse(dtos, dtos.LongCount());
    }

    public async Task<ApiResponseDto<MainGridDto>> GetByIdAsync(long id)
    {
        var mainGrid = await context.MainGrids
            .Include(f => f.Actuals)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (mainGrid == null)
            return ApiResponseDto<MainGridDto>.FailureResponse("Record not found.");

        return ApiResponseDto<MainGridDto>.SuccessResponse(_mapper.Map<MainGridDto>(mainGrid), 1);
    }

    public async Task<ApiResponseDto<MainGridDto>> CreateAsync(MainGridDto mainGridDto)
    {
        var mainGrid = _mapper.Map<MainGrid>(mainGridDto);

        context.MainGrids.Add(mainGrid);
        await context.SaveChangesAsync();

        return ApiResponseDto<MainGridDto>.SuccessResponse(_mapper.Map<MainGridDto>(mainGrid), 1, message: "Record created successfully.");
    }

    public async Task<ApiResponseDto<MainGridDto>> UpdateAsync(MainGridDto mainGridDto)
    {
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

    public async Task<ApiResponse> DeleteAsync(long id)
    {
        var mainGrid = await context.MainGrids.FindAsync(id);

        if (mainGrid == null)
            return ApiResponse.FailureResponse("Record not found.");

        context.MainGrids.Remove(mainGrid);
        await context.SaveChangesAsync();

        return ApiResponse.SuccessResponse("Record deleted successfully.");
    }
}
