using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;

namespace CleanArch.Application.Services;

public class SalesStatsService(ISalesStatsRepository repository)
{
    public async Task<IEnumerable<SalesStatDto>> GetSalesStatsAsync()
    {
        var stats = await repository.GetSalesStatsAsync();
        return stats.Select(s => new SalesStatDto
        {
            Id = s.Id,
            Date = s.Date,
            Amount = s.Amount,
            Category = s.Category,
            TransactionCount = s.TransactionCount
        });
    }
}
