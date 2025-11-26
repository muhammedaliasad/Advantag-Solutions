using Application.DTOs;

namespace Infrastructure.Interfaces;

public interface ISalesService
{
    Task<IEnumerable<SaleDto>> GetAllAsync();
}
