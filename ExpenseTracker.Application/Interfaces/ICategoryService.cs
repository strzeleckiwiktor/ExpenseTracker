using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAll();
        public Task<Category?> GetById(long id);
        public Task<long> Create(Category category);
        public Task<Category?> Update(long id, string name);
        public Task<Category?> Delete(long id);
    }
}
