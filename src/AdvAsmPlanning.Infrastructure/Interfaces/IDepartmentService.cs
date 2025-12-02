using AdvAsmPlanning.Application;
using AdvAsmPlanning.Application.DTOs;

namespace AdvAsmPlanning.Infrastructure.Interfaces;

public interface IDepartmentService
{
    Task<ApiResponseDto<IEnumerable<DropdownDto>>> GetAllAsync(string key);
}
