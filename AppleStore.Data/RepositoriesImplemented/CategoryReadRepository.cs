using AppleStore.Data.Configuration;
using AppleStore.Domain.Entities;
using AppleStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AppleStore.Data.RepositoriesImplemented
{
    public sealed class CategoryReadRepository : ICategoryReadRepository
    {
        private ApplicationDbContext _context;

        public CategoryReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Categories.SingleOrDefaultAsync(c => c.Id.Equals(id));
                if (result is null)
                    return null;

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Category>> GetByTitleAsync(string title)
        {
            try
            {
                using (_context)
                {
                    var categories = await _context.Categories
                        .Where(c => c.Title.Normalize().Contains(title.Normalize()))
                        .AsNoTracking()
                        .Take(20)
                        .ToListAsync();

                    return categories;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Category>> ReadAllAsync()
        {
            try
            {
                return await _context.Categories
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
