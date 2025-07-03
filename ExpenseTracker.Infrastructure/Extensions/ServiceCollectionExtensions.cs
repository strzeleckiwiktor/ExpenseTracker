using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ExpenseTracker.Domain.Repositories;
using ExpenseTracker.Infrastructure.Repositories;

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

            services.AddScoped<ICategoryRepository, CategoryRepositoryImpl>();
            services.AddScoped<IExpenseRepository, ExpenseRepositoryImpl>();

            //services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<ExpenseTrackerDbContext>();
        }
    }
}
