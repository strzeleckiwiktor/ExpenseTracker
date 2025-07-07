using ExpenseTracker.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Reflection;

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

            (HttpStatusCode statusCode, string title) = exception switch
            {
                NotFoundException => (HttpStatusCode.NotFound, "Not Found"),
                ArgumentException => (HttpStatusCode.BadRequest, "Bad Request"),
                _ => (HttpStatusCode.InternalServerError, "Server Error")
            };

            httpContext.Response.StatusCode = (int)statusCode;

            var problemDetails = new ProblemDetails()
            {
                Title = title,
                Status = (int)statusCode,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }
    }
}
