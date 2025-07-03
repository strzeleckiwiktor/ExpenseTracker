using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Domain.Repositories
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<Category?> GetByIdAsync(long id);
        public Task<long> CreateAsync(Category category);
        public Task<Category> UpdateAsync(Category category);
        public Task<Category> DeleteAsync(Category category);
    }
}
