using AppleStore.Application.Output.ViewModels;

namespace AppleStore.Application.Output.Repositories
{
    public interface ICategoryReadService
    {
        Task<List<CategoryViewModel>> ReadAllAsync();
        Task<CategoryViewModel> GetByIdAsync(Guid id);
        Task<List<CategoryViewModel>> GetByTitleAsync(string title);

    }
}
