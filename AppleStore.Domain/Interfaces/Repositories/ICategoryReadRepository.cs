using AppleStore.Domain.Entities;

namespace AppleStore.Domain.Interfaces.Repositories
{
    public interface ICategoryReadRepository
    {
        Task<List<Category>> ReadAllAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task<List<Category>> GetByTitleAsync(string title);

    }
}
