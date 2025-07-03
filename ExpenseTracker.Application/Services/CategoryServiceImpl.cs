using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.Application.Services
{
    internal class CategoryServiceImpl(
        ICategoryRepository repository,
        ILogger<CategoryServiceImpl> logger
        ) : ICategoryService
    {
        public async Task<IEnumerable<Category>> GetAll()
        {
            logger.LogInformation("Getting all categories");
            var categories = await repository.GetAllAsync();

            return categories!;
        }

        public async Task<Category?> GetById(long id)
        {
            var category = await repository.GetByIdAsync(id);

            return category;
        }

        public async Task<long> Create(Category category)
        {
            var id = await repository.CreateAsync(category);

            return id;
        }

        public async Task<Category?> Update(long id, String name)
        {
            var category = await repository.GetByIdAsync(id);

            if (category == null)
            {
                return null;
            }

            category.Name = name;

            var updatedCategory = await repository.UpdateAsync(category);

            return updatedCategory;
        }

        public async Task<Category?> Delete(long id)
        {
            var category = await repository.GetByIdAsync(id);

            if (category == null)
            {
                return null;
            }

            await repository.DeleteAsync(category);
            return category;
        }
    }
}

