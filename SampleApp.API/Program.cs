using ExpenseTracker.API.Extensions;
using ExpenseTracker.Application.Extensions;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Extensions;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePresentationServices();

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AuthDbContext>();


var app = builder.Build();
app.UseExceptionHandler(_ => { });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.MapGroup("api/auth").MapIdentityApi<User>();

app.UseAuthorization();
app.MapIdentityApi<User>();



app.MapControllers();

app.Run();
