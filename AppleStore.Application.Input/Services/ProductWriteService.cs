using AppleStore.Application.Input.InputModels;
using AppleStore.Application.Input.Repositories;
using AppleStore.Domain.Interfaces.Repositories;

namespace AppleStore.Application.Input.Services
{
    public sealed class ProductWriteService : IProductWriteService
    {
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductWriteService(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task AddAsync(ProductInputModel model)
        {
            var entity = model.ToEntity();

            await _productWriteRepository.AddAsync(entity);
            await _productWriteRepository.Commit();
        }

        public async Task<bool> Delete(Guid id)
        {
            await _productWriteRepository.Delete(id);
            await _productWriteRepository.Commit();

            return true;
        }

        public async Task UpdateAsync(ProductInputModel model)
        {
            var entity = model.ToEntity();
            await _productWriteRepository.UpdateAsync(entity);
            await _productWriteRepository.Commit();
        }
    }
}
