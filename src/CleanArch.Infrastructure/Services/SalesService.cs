using Application.DTOs;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class SalesService(IRepository<Sale> repository) : ISalesService
{
    public async Task<IEnumerable<SaleDto>> GetAllAsync()
    {
        var stats = await repository.GetAllAsync();
        return stats.Select(s => new SaleDto
        {
            Id = s.Id,
            Date = s.Date,
            Amount = s.Amount
        });
    }
}
