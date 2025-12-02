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
            "AccountName" => accounts
                .Where(d => !string.IsNullOrEmpty(d.Code) || !string.IsNullOrEmpty(d.Description))
                .Select(d => new DropdownDto
                {
                    Label = $"{d.Code}_{d.Description}",
                    Value = $"{d.Code}_{d.Description}"
                })
                .Distinct(),
            "c_ExtReport" => accounts
                .Where(d => !string.IsNullOrEmpty(d.c_ExtReport))
                .DistinctBy(d => d.c_ExtReport)
                .Select(d => new DropdownDto
                {
                    Label = d.c_ExtReport,
                    Value = d.c_ExtReport
                }),
            "c_Accountgroup" => accounts
                .Join(accounts,
                      a => a.MemberId,
                      acc => acc.MemberId,
                      (a, acc) => acc)
                .Where(acc => !string.IsNullOrEmpty(acc.c_RollupLevel1))
                .Select(d => new DropdownDto
                {
                    Label = d.c_RollupLevel1.Length < 4 ? d.c_RollupLevel1.Substring(d.c_RollupLevel1.Length - 3) : d.c_RollupLevel1.Substring(3),
                    Value = d.c_RollupLevel1.Length < 4 ? d.c_RollupLevel1.Substring(d.c_RollupLevel1.Length - 3) : d.c_RollupLevel1.Substring(3)
                }).Distinct(),
            "c_AccountSubgroup" => accounts
                .Where(d => !string.IsNullOrEmpty(d.c_AccountSubgroup))
                .DistinctBy(d => d.c_AccountSubgroup)
                .Select(d => new DropdownDto
                {
                    Label = d.c_AccountSubgroup,
                    Value = d.c_AccountSubgroup
                }),
            _ => []
        };

        return ApiResponseDto<IEnumerable<DropdownDto>>.SuccessResponse(dropdowns, dropdowns.LongCount());
    }
}
