using AppleStore.Data.Configuration;
using AppleStore.Domain.Entities;
using AppleStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AppleStore.Data.RepositoriesImplemented
{
    public sealed class ProductWriteRepository : IProductWriteRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductWriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            try
            {
                using (_context)
                {
                    var result = await _context.Products.SingleOrDefaultAsync(c => c.Id.Equals(product.Id));

                    product.CreateAt = DateTime.Now;
                    _context.Add(result);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(Product product)
        {
            try
            {
                var result = await _context.Products.SingleOrDefaultAsync(c => c.Id.Equals(product.Id));
                if (result != null)
                {
                    product.UpdateAt = DateTime.Now;
                    product.CreateAt = result.CreateAt;

                    result.Update(product.Title, product.Description, product.ImgUrl, product.Price, product.Stock);

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = _context.Products.SingleOrDefault(c => c.Id.Equals(id));
                if (result is null)
                    return false;

                result.Delete();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return true;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
