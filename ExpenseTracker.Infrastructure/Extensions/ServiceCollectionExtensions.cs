using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using ExpenseTracker.Infrastructure.Persistence;
using ExpenseTracker.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ExpenseTrackerConnectionString");
            services.AddDbContext<ExpenseTrackerDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddDbContext<AuthDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ICategoryRepository, CategoryRepositoryImpl>();
            services.AddScoped<IExpenseRepository, ExpenseRepositoryImpl>();
            services.AddScoped<IBudgetRepository, BudgetRepositoryImpl>();

            
        }
    }
}
