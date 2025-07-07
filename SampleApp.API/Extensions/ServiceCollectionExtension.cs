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

            services.AddAutoMapper(applicationAssembly);

            services.AddValidatorsFromAssembly(applicationAssembly);
            services.AddExceptionHandler<GlobalExceptionHandler>();
            //services.AddFluentValidationAutoValidation();
        }
    }
}
