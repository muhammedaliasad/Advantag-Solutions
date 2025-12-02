using AdvAsmPlanning.Application;
using AdvAsmPlanning.Application.DTOs;

namespace AdvAsmPlanning.Infrastructure.Interfaces;

public interface IDropdownService
{
    Task<ApiResponseDto<IEnumerable<DropdownDto>>> GetAllAsync(string key);
}
