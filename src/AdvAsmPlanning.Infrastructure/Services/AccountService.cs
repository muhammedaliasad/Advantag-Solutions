using AdvAsmPlanning.Application;
using AdvAsmPlanning.Application.DTOs;
using AdvAsmPlanning.Domain.Entities;
using AdvAsmPlanning.Infrastructure.Interfaces;

namespace AdvAsmPlanning.Infrastructure.Services;

public class AccountService(IRepository<Account> repository) : IAccountService
{
    public async Task<ApiResponseDto<IEnumerable<DropdownDto>>> GetAllAsync(string key)
    {

        if (string.IsNullOrEmpty(key))
            return ApiResponseDto<IEnumerable<DropdownDto>>.FailureResponse("Key not found.");

        IEnumerable<Account> accounts = await repository.GetAllAsync();

        IEnumerable<DropdownDto> dropdowns = key switch
        {
            "c_AccountSubgroup" => accounts
                .Where(d => !string.IsNullOrEmpty(d.c_AccountSubgroup))
                .DistinctBy(d => d.c_AccountSubgroup)
                .Select(d => new DropdownDto
                {
                    Label = d.c_AccountSubgroup,
                    Value = d.c_AccountSubgroup
                }),
            "c_ExtReport" => accounts
                .Where(d => !string.IsNullOrEmpty(d.c_ExtReport))
                .DistinctBy(d => d.c_ExtReport)
                .Select(d => new DropdownDto
                {
                    Label = d.c_ExtReport,
                    Value = d.c_ExtReport
                }),
            _ => Enumerable.Empty<DropdownDto>()
        };

        return ApiResponseDto<IEnumerable<DropdownDto>>.SuccessResponse(dropdowns, dropdowns.LongCount());
    }
}
