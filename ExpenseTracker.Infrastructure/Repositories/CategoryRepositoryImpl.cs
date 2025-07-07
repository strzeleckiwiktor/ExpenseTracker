using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using ExpenseTracker.Infrastructure.Persistence;
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
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(long id)
        {
            return await dbContext.Categories.AnyAsync(c => c.Id == id);
        }
    }
}
