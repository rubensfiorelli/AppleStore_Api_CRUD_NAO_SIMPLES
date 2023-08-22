using AppleStore.Application.Output.ViewModels;

namespace AppleStore.Application.Output.Repositories
{
    public interface IProductReadService
    {
        Task<List<ProductViewModel>> ReadAllAsync();
        Task<ProductViewModel> GetByIdAsync(Guid id);
    }
}
