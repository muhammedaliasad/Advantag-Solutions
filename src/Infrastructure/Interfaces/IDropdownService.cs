using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IDropdownService
{
    Task<IEnumerable<Dropdown>> GetAllAsync(string key);
    Task<Dropdown?> GetByIdAsync(long id);
    Task AddAsync(Dropdown dto);
    Task UpdateAsync(Dropdown dto);
    Task RemoveAsync(long id);
}
