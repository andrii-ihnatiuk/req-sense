using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ReqSense.Application.Common.Exceptions;

namespace ReqSense.API.Middlewares;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    private readonly ILogger _logger = logger;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        StackTrace trace = new(exception, true);
        var method = trace.GetFrame(0)?.GetMethod()?.ReflectedType?.FullName;
        _logger.LogError($"An error occurred in {method}: {exception.Message}");

        var problemDetails = exception switch
        {
            GeminiException e => HandleGeminiException(e),
            _ => HandleUnknownException(exception)
        };

        httpContext.Response.StatusCode = problemDetails.Status!.Value;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static ProblemDetails HandleGeminiException(GeminiException exception)
    {
        return new ProblemDetails
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-500-internal-server-error",
            Title = "An error occurred while processing the response from the third-party service.",
            Status = StatusCodes.Status500InternalServerError,
            Detail = exception.Message,
        };
    }

    private static ProblemDetails HandleUnknownException(Exception exception)
    {
        return new ProblemDetails
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-500-internal-server-error",
            Title = "Critical error",
            Status = StatusCodes.Status500InternalServerError,
            Detail = "An unexpected error occurred while processing the request.",
        };
    }
}