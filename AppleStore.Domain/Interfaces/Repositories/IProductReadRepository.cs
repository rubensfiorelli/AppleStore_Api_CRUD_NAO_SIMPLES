using AppleStore.Domain.Entities;

namespace AppleStore.Domain.Interfaces.Repositories
{
    public interface IProductReadRepository
    {
        Task<List<Product>> ReadAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task<Product> GetProductCategory(Guid id);
    }
}
