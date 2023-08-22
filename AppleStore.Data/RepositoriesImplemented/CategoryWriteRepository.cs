using AppleStore.Data.Configuration;
using AppleStore.Domain.Entities;
using AppleStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AppleStore.Data.RepositoriesImplemented
{
    public sealed class CategoryWriteRepository : ICategoryWriteRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryWriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            try
            {
                var result = await _context.Categories.SingleOrDefaultAsync(c => c.Id.Equals(category.Id));

                if (result is null)
                    category.CreateAt = DateTime.Now;

                _context.AddAsync(category);


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(Category category)
        {
            try
            {
                var result = await _context.Categories.SingleOrDefaultAsync(c => c.Id.Equals(category.Id));
                if (result != null)
                {
                    category.UpdateAt = DateTime.Now;
                    category.CreateAt = result.CreateAt;

                    result.Update(category.Title, category.Description, category.ImgUrl);

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
                var result = _context.Categories.SingleOrDefault(c => c.Id.Equals(id));

                result?.Delete();
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
