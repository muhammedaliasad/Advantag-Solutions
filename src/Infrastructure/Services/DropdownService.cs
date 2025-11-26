using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class DropdownService : IDropdownService
{
    private readonly IRepository<Dropdown> _repository;

    public DropdownService(IRepository<Dropdown> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Dropdown>> GetAllAsync(string key)
    {
        if (string.IsNullOrEmpty(key))
            return await _repository.GetAllAsync();

        return await _repository.FindAsync(d => d.Key == key);
    }

    public async Task<Dropdown?> GetByIdAsync(long id) => await _repository.GetByIdAsync(id);

    public async Task AddAsync(Dropdown dto) => await _repository.AddAsync(dto);

    public async Task UpdateAsync(Dropdown dto) => _repository.Update(dto);

    public async Task RemoveAsync(long id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is not null)
            _repository.Remove(entity);
    }
}
