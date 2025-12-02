using AdvAsmPlanning.Application;
using AdvAsmPlanning.Application.DTOs;
using AdvAsmPlanning.Domain.Database;
using AdvAsmPlanning.Domain.Entities;
using AdvAsmPlanning.Infrastructure.Interfaces;

namespace AdvAsmPlanning.Infrastructure.Services;

public class DropdownService(IRepository<Account> accountRepository, IRepository<Department> departmentRepository) : IDropdownService
{
    public async Task<ApiResponseDto<IEnumerable<DropdownDto>>> GetAllAsync(string key)
    {

        if (string.IsNullOrEmpty(key))
            return ApiResponseDto<IEnumerable<DropdownDto>>.FailureResponse("Key not found.");

        IEnumerable<Account> accounts = await accountRepository.GetAllAsync();
        IEnumerable<Department> departments = await departmentRepository.GetAllAsync();

        IEnumerable<DropdownDto> dropdowns = key switch
        {
            DropdownKeys.AccountName => accounts
                .Where(d => !string.IsNullOrEmpty(d.Code) || !string.IsNullOrEmpty(d.Description))
                .Select(d => new DropdownDto
                {
                    Label = $"{d.Code}_{d.Description}",
                    Value = $"{d.Code}_{d.Description}"
                })
                .Distinct(),
            DropdownKeys.AccountExternalReport => accounts
                .Where(d => !string.IsNullOrEmpty(d.c_ExtReport))
                .DistinctBy(d => d.c_ExtReport)
                .Select(d => new DropdownDto
                {
                    Label = d.c_ExtReport,
                    Value = d.c_ExtReport
                }),
            DropdownKeys.AccountGroup => accounts
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
            DropdownKeys.AccountSubGroup => accounts
                .Where(d => !string.IsNullOrEmpty(d.c_AccountSubgroup))
                .DistinctBy(d => d.c_AccountSubgroup)
                .Select(d => new DropdownDto
                {
                    Label = d.c_AccountSubgroup,
                    Value = d.c_AccountSubgroup
                }),
            DropdownKeys.BusinessUnit => departments
                .Where(d => !string.IsNullOrEmpty(d.c_BusinessUnit))
                .DistinctBy(d => d.c_BusinessUnit)
                .Select(d => new DropdownDto { Label = d.c_BusinessUnit, Value = d.c_BusinessUnit }),
            DropdownKeys.Division => departments
                .Where(d => !string.IsNullOrEmpty(d.c_Division))
                .DistinctBy(d => d.c_Division)
                .Select(d => new DropdownDto { Label = d.c_Division, Value = d.c_Division }),
            DropdownKeys.Market => departments
                .Where(d => !string.IsNullOrEmpty(d.c_Market))
                .DistinctBy(d => d.c_Market)
                .Select(d => new DropdownDto { Label = d.c_Market, Value = d.c_Market }),
            _ => []
        };

        return ApiResponseDto<IEnumerable<DropdownDto>>.SuccessResponse(dropdowns, dropdowns.LongCount());
    }
}
