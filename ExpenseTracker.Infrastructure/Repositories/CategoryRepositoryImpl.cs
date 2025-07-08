using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using ExpenseTracker.Infrastructure.Exceptions;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories
{
    internal class CategoryRepositoryImpl(ExpenseTrackerDbContext dbContext) : ICategoryRepository
    {

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await dbContext.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category?> GetByIdAsync(long id)
        {
            var category = await dbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<long> CreateAsync(Category category)
        {
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
            return category.Id;
        }

        public async Task UpdateAsync(Category category)
        {
            dbContext.Categories.Update(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            try
            {
                dbContext.Categories.Remove(category);
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
                {
                    throw new ForeignKeyConstraintViolationException("Cannot delete entity due to related records.", ex);
                }
                throw;
            }
        }

        public async Task<bool> ExistsAsync(long id)
        {
            return await dbContext.Categories.AnyAsync(c => c.Id == id);
        }
    }
}
