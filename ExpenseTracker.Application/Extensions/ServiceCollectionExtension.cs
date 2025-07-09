using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryServiceImpl>();
            services.AddScoped<IExpenseService, ExpenseServiceImpl>();
            services.AddScoped<IBudgetService, BudgetServiceImpl>();
        }
    }
}
