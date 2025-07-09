using FluentValidation;
using FluentValidation.AspNetCore;

namespace ExpenseTracker.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigurePresentationServices(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceCollectionExtension).Assembly;

            services.AddControllers();

            services.AddExceptionHandler<GlobalExceptionHandler>();

            services.AddAutoMapper(applicationAssembly);

            services.AddValidatorsFromAssembly(applicationAssembly);
            services.AddFluentValidationAutoValidation();
        }
    }
}
