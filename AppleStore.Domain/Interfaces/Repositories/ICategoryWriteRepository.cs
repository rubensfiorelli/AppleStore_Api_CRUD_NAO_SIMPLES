using AppleStore.Domain.Entities;

namespace AppleStore.Domain.Interfaces.Repositories
{
    public interface ICategoryWriteRepository : IUnitOfWork
    {
        Task AddAsync(Category category);
        Task<bool> Delete(Guid id);
        Task UpdateAsync(Category category);
    }
}
