using AppleStore.Application.Output.Repositories;
using AppleStore.Application.Output.ViewModels;
using AppleStore.Domain.Interfaces.Repositories;

namespace AppleStore.Application.Output.Services
{
    public class CategoryReadService : ICategoryReadService
    {
        private readonly ICategoryReadRepository _CategoryReadRepository;

        public CategoryReadService(ICategoryReadRepository categoryReadRepository)
        {
            _CategoryReadRepository = categoryReadRepository;
        }

        public async Task<CategoryViewModel> GetByIdAsync(Guid id)
        {

            var category = await _CategoryReadRepository.GetByIdAsync(id);

            return CategoryViewModel.FromEntity(category);

        }

        public async Task<List<CategoryViewModel>> GetByTitleAsync(string title)
        {
            var category = await _CategoryReadRepository.GetByTitleAsync(title);

            return category
                    .Select(x => new CategoryViewModel(x.Id, x.Title, x.Description, x.ImgUrl, x.CreateAt))
                    .ToList();

        }

        public async Task<List<CategoryViewModel>> ReadAllAsync()
        {
            var category = await _CategoryReadRepository.ReadAllAsync();

            return category
                .Select(s => new CategoryViewModel(s.Id, s.Title, s.Description, s.ImgUrl, s.CreateAt))
                .ToList();

        }
    }
}
