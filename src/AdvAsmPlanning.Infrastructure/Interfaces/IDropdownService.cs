namespace AdvAsmPlanning.Infrastructure.Interfaces;

public interface IDropdownService
{
    Task<ApiResponseDto<IEnumerable<DropdownResponseDto>>> GetAllAsync(DropdownKey key);
}
