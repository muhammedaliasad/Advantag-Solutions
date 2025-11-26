using CleanArch.Domain.Entities;

namespace CleanArch.Application.Interfaces;

public interface ISalesStatsRepository
{
    Task<IEnumerable<SalesStat>> GetSalesStatsAsync();
}
