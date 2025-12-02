using AdvAsmPlanning.Application;
using AdvAsmPlanning.Application.Constants;
using AdvAsmPlanning.Application.DTOs;

namespace AdvAsmPlanning.Infrastructure.Interfaces;

public interface IDropdownService
{
    Task<ApiResponseDto<IEnumerable<DropdownResponseDto>>> GetAllAsync(DropdownKey key);
}
