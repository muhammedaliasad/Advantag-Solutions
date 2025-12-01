using AdvAsmPlanning.Domain.Entities;
using AdvAsmPlanning.Infrastructure.Interfaces;

namespace AdvAsmPlanning.Infrastructure.Services;

public class DropdownService(IRepository<Dropdown> repository) : IDropdownService
{
    public async Task<IEnumerable<Dropdown>> GetAllAsync(string key)
    {
        if (string.IsNullOrEmpty(key))
            return await repository.GetAllAsync();

        return await repository.FindAsync(d => d.Key == key);
    }

    public async Task<Dropdown?> GetByIdAsync(long id) => await repository.GetByIdAsync(id);

    public async Task AddAsync(Dropdown dto) => await repository.AddAsync(dto);

    public async Task UpdateAsync(Dropdown dto) { repository.Update(dto); await Task.CompletedTask; }

    public async Task RemoveAsync(long id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is not null)
            repository.Remove(entity);
    }
}
