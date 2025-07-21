using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAll();
        public Task<Category?> GetById(long id);
        public Task<Category?> GetCategoryWithExpensesById(long id);
        public Task<long> Create(Category category);
        public Task Update(long id, string name);
        public Task Delete(long id);
    }
}
