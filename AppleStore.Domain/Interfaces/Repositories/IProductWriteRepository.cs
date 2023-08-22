using AppleStore.Domain.Entities;

namespace AppleStore.Domain.Interfaces.Repositories
{
    public interface IProductWriteRepository : IUnitOfWork
    {
        Task AddAsync(Product product);
        Task<bool> Delete(Guid id);
        Task UpdateAsync(Product product);
    }
}
