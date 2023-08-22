using AppleStore.Application.Input.InputModels;
using AppleStore.Application.Output.ViewModels;

namespace AppleStore.Application.Input.Repositories
{
    public interface ICategoryWriteService
    {
        Task<CategoryViewModel> AddAsync(CategoryInputModel model);
        Task<bool> Delete(Guid id);
        Task<CategoryViewModel> UpdateAsync(CategoryInputModel model);
    }
}