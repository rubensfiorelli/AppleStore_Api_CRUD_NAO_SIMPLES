using AppleStore.Data.Configuration;
using AppleStore.Domain.Entities;
using AppleStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AppleStore.Data.RepositoriesImplemented
{
    public sealed class ProductReadRepository : IProductReadRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Products.SingleOrDefaultAsync(c => c.Id.Equals(id));
                if (result is null)
                    return null;

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetProductCategory(Guid id)
        {
            try
            {
                var result = await _context.Products
                    .Include(c => c.Category)
                    .SingleOrDefaultAsync(c => c.Id.Equals(id));
                if (result is null)
                    return null;

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Product>> ReadAllAsync()
        {
            try
            {
                return await _context.Products
                    .Take(20)
                    .ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
