using Application.DTOs;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class SalesService : ISalesService
{
    private readonly IRepository<Sale> _repository;

    public SalesService(IRepository<Sale> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SaleDto>> GetAllAsync()
    {
        var stats = await _repository.GetAllAsync();
        return stats.Select(s => new SaleDto
        {
            Id = s.Id,
            Date = s.Date,
            Amount = s.Amount
        });
    }
}
