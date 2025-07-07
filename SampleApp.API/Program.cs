using ExpenseTracker.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;
using ExpenseTracker.Application.Extensions;
using ExpenseTracker.API.Mappers;
using FluentValidation;
using ExpenseTracker.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type =  ReferenceType.SecurityScheme, Id = "bearerAuth" }
            },
            []
        }
    });
});

builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePresentationServices();


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

app.MapControllers();

app.Run();
