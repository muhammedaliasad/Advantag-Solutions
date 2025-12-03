namespace AdvAsmPlanning.Infrastructure.Interfaces;

public interface IMainGridService
{
    Task<ApiResponseDto<IEnumerable<MainGridDto>>> GetAllAsync();
    Task<ApiResponseDto<MainGridDto>> GetByIdAsync(long id);
    Task<ApiResponseDto<MainGridDto>> CreateAsync(MainGridDto mainGridDto);
    Task<ApiResponseDto<MainGridDto>> UpdateAsync(MainGridDto mainGridDto);
    Task<ApiResponse> DeleteAsync(long id);
}
