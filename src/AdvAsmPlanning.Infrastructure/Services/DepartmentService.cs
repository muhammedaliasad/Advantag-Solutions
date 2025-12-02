using AdvAsmPlanning.Application;
using AdvAsmPlanning.Application.DTOs;
using AdvAsmPlanning.Domain.Database;
using AdvAsmPlanning.Domain.Entities;
using AdvAsmPlanning.Infrastructure.Interfaces;
using AutoMapper;

namespace AdvAsmPlanning.Infrastructure.Services;

public class DepartmentService(IRepository<Department> repository) : IDepartmentService
{
    public async Task<ApiResponseDto<IEnumerable<DropdownDto>>> GetAllAsync(string key)
    {
        if (string.IsNullOrEmpty(key))
            return ApiResponseDto<IEnumerable<DropdownDto>>.FailureResponse("Key not found.");

        IEnumerable<Department> departments = await repository.GetAllAsync();
        IEnumerable<DropdownDto> dropdowns = key switch
        {
            "c_BusinessUnit" => departments
                .Where(d => !string.IsNullOrEmpty(d.c_BusinessUnit))
                .DistinctBy(d => d.c_BusinessUnit)
                .Select(d => new DropdownDto { Label = d.c_BusinessUnit, Value = d.c_BusinessUnit }),
            "c_Division" => departments
                .Where(d => !string.IsNullOrEmpty(d.c_Division))
                .DistinctBy(d => d.c_Division)
                .Select(d => new DropdownDto { Label = d.c_Division, Value = d.c_Division }),
            "c_Market" => departments
                .Where(d => !string.IsNullOrEmpty(d.c_Market))
                .DistinctBy(d => d.c_Market)
                .Select(d => new DropdownDto { Label = d.c_Market, Value = d.c_Market }),
            _ => Enumerable.Empty<DropdownDto>()
        };

        return ApiResponseDto<IEnumerable<DropdownDto>>.SuccessResponse(dropdowns, dropdowns.LongCount());
    }

}
