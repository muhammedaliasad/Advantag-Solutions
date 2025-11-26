using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Repositories;

public class SalesStatsRepository : ISalesStatsRepository
{
    private readonly AppDbContext _context;

    public SalesStatsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SalesStat>> GetSalesStatsAsync()
    {
        return await _context.SalesStats.ToListAsync();
    }
}
