using ExpenseTracker.Application.Exceptions;
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
            var categories = await repository.GetAllAsync();
            return categories!;
        }

        public async Task<Category?> GetById(long id)
        {
            var category = await repository.GetByIdAsync(id);

            if (category == null)
            {
                throw new NotFoundException($"Category with Id {id} not found.");
            }

            return category;
        }

        public async Task<long> Create(Category category)
        {
            var id = await repository.CreateAsync(category);
            return id;
        }

        public async Task Update(long id, String name)
        {
            var category = await repository.GetByIdAsync(id);

            if (category == null)
            {
                throw new NotFoundException($"Category with Id {id} not found.");
            }

            category.Name = name;
            await repository.UpdateAsync(category);
        }

        public async Task Delete(long id)
        {
            var category = await repository.GetByIdAsync(id);

            if (category == null)
            {
                throw new NotFoundException($"Category with Id {id} not found.");
            }

            await repository.DeleteAsync(category);
        }
    }
}

