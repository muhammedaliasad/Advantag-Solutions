using AdvAsmPlanning.Application;
using AdvAsmPlanning.Application.Constants;
using AdvAsmPlanning.Application.DTOs;
using AdvAsmPlanning.Domain.Database;
using AdvAsmPlanning.Domain.Entities;
using AdvAsmPlanning.Infrastructure.Interfaces;
using System.Linq;

namespace AdvAsmPlanning.Infrastructure.Services;

public class DropdownService(IRepository<Account> accountRepository, IRepository<Department> departmentRepository) : IDropdownService
{
    public async Task<ApiResponseDto<IEnumerable<DropdownResponseDto>>> GetAllAsync(DropdownKey key)
    {
        IEnumerable<DropdownResponseDto> dropdowns;

        switch (key)
        {
            case DropdownKey.AccountName:
            {
                var accounts = await accountRepository.GetAllAsync();
                dropdowns = accounts
                    .Where(d => !string.IsNullOrEmpty(d.Code) || !string.IsNullOrEmpty(d.Description))
                    .Select(d => new DropdownResponseDto { Label = $"{d.Code}_{d.Description}", Value = $"{d.Code}_{d.Description}" })
                    .DistinctBy(dto => dto.Value);
                break;
            }

            case DropdownKey.AccountExternalReport:
            {
                var accounts = await accountRepository.GetAllAsync();
                dropdowns = accounts
                    .Where(d => !string.IsNullOrEmpty(d.c_ExtReport))
                    .DistinctBy(d => d.c_ExtReport)
                    .Select(d => new DropdownResponseDto { Label = d.c_ExtReport!, Value = d.c_ExtReport! });
                break;
            }

            case DropdownKey.AccountGroup:
            {
                var accounts = await accountRepository.GetAllAsync();
                dropdowns = accounts.Join(accounts, a => a.MemberId, acc => acc.MemberId, (a, acc) => acc)
                    .Where(acc => !string.IsNullOrEmpty(acc.c_RollupLevel1))
                    .Select(d => new DropdownResponseDto
                    {
                        Label = d.c_RollupLevel1!.Length < 4 ? d.c_RollupLevel1.Substring(d.c_RollupLevel1.Length - 3) : d.c_RollupLevel1.Substring(3),
                        Value = d.c_RollupLevel1!.Length < 4 ? d.c_RollupLevel1.Substring(d.c_RollupLevel1.Length - 3) : d.c_RollupLevel1.Substring(3)
                    })
                    .DistinctBy(x => x.Value);
                break;
            }

            case DropdownKey.AccountSubGroup:
            {
                var accounts = await accountRepository.GetAllAsync();
                dropdowns = accounts
                    .Where(d => !string.IsNullOrEmpty(d.c_AccountSubgroup))
                    .DistinctBy(d => d.c_AccountSubgroup)
                    .Select(d => new DropdownResponseDto { Label = d.c_AccountSubgroup!, Value = d.c_AccountSubgroup! });
                break;
            }

            case DropdownKey.BusinessUnit:
            {
                var departments = await departmentRepository.GetAllAsync();
                dropdowns = departments
                    .Where(d => !string.IsNullOrEmpty(d.c_BusinessUnit))
                    .DistinctBy(d => d.c_BusinessUnit)
                    .Select(d => new DropdownResponseDto { Label = d.c_BusinessUnit!, Value = d.c_BusinessUnit! });
                break;
            }

            case DropdownKey.Division:
            {
                var departments = await departmentRepository.GetAllAsync();
                dropdowns = departments
                    .Where(d => !string.IsNullOrEmpty(d.c_Division))
                    .DistinctBy(d => d.c_Division)
                    .Select(d => new DropdownResponseDto { Label = d.c_Division!, Value = d.c_Division! });
                break;
            }

            case DropdownKey.Market:
            {
                var departments = await departmentRepository.GetAllAsync();
                dropdowns = departments
                    .Where(d => !string.IsNullOrEmpty(d.c_Market))
                    .DistinctBy(d => d.c_Market)
                    .Select(d => new DropdownResponseDto { Label = d.c_Market!, Value = d.c_Market! });
                break;
            }

            default:
                dropdowns = Enumerable.Empty<DropdownResponseDto>();
                break;
        }

        return ApiResponseDto<IEnumerable<DropdownResponseDto>>.SuccessResponse(dropdowns, dropdowns.LongCount());
    }
}
