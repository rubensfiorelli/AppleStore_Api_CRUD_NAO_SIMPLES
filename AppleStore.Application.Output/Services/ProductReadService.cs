using AppleStore.Application.Output.Repositories;
using AppleStore.Application.Output.ViewModels;
using AppleStore.Domain.Interfaces.Repositories;

namespace AppleStore.Application.Output.Services
{
    public sealed class ProductReadService : IProductReadService
    {
        private readonly IProductReadRepository _productReadRepository;

        public ProductReadService(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<ProductViewModel> GetByIdAsync(Guid id)
        {
            var product = await _productReadRepository.GetByIdAsync(id);

            return ProductViewModel.FromEntity(product);
        }

        public async Task<List<ProductViewModel>> ReadAllAsync()
        {
            var product = await _productReadRepository.ReadAllAsync();

            return product
                .Select(s => new ProductViewModel(s.Id, s.Title, s.Description, s.ImgUrl, s.Price, s.Stock,
                        s.CategoryId, s.CreateAt))
                .ToList();
        }
    }
}
