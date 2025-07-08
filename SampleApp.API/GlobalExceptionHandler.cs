using ExpenseTracker.Application.Exceptions;
using ExpenseTracker.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExpenseTracker.API
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogInformation("TryHandleAsync called");

            (int statusCode, string title) = exception switch
            {
                NotFoundException => (StatusCodes.Status404NotFound, "Not Found"),
                ArgumentException => (StatusCodes.Status400BadRequest, "Bad Request"),
                ForeignKeyConstraintViolationException => (StatusCodes.Status409Conflict, "Conflict"),
                _ => (StatusCodes.Status500InternalServerError, "Server Error")
            };

            httpContext.Response.StatusCode = statusCode;

            var problemDetails = new ProblemDetails()
            {
                Title = title,
                Status = statusCode,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }
    }
}
