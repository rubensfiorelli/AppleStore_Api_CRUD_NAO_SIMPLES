using AppleStore.Application.Input.InputModels;
using AppleStore.Application.Input.Repositories;
using AppleStore.Application.Output.ViewModels;
using AppleStore.Domain.Interfaces.Repositories;

namespace AppleStore.Application.Input.Services
{
    public sealed class CategoryWriteService : ICategoryWriteService
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public CategoryWriteService(ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<CategoryViewModel> AddAsync(CategoryInputModel model)
        {
            var entity = model.ToEntity();

            await _categoryWriteRepository.AddAsync(entity);
            await _categoryWriteRepository.Commit();

            return CategoryViewModel.FromEntity(entity);

        }

        public async Task<bool> Delete(Guid id)
        {
            await _categoryWriteRepository.Delete(id);
            await _categoryWriteRepository.Commit();

            return true;
        }

        public async Task<CategoryViewModel> UpdateAsync(CategoryInputModel model)
        {
            var entity = model.ToEntity();
            await _categoryWriteRepository.UpdateAsync(entity);
            await _categoryWriteRepository.Commit();

            return CategoryViewModel.FromEntity(entity);
        }

    }
}
