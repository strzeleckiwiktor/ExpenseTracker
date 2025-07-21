using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Domain.Repositories
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<Category?> GetByIdAsync(long id);
        public Task<Category?> GetCategoryWithExpensesByIdAsync(long id);
        public Task<long> CreateAsync(Category category);
        public Task UpdateAsync(Category category);
        public Task DeleteAsync(Category category);
        public Task<bool> ExistsAsync(long id);
    }
}
