using AppleStore.Application.Input.InputModels;

namespace AppleStore.Application.Input.Repositories
{
    public interface IProductWriteService
    {
        Task AddAsync(ProductInputModel model);
        Task<bool> Delete(Guid id);
        Task UpdateAsync(ProductInputModel model);
    }
}
