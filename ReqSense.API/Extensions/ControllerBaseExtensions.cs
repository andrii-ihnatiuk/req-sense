using Microsoft.AspNetCore.Mvc;
using ReqSense.Application.Common.Errors.Base;
using ReqSense.Domain.Common;

namespace ReqSense.API.Extensions;

public static class ControllerBaseExtensions
{
    public static IActionResult FromError<TError>(this ControllerBase c, TError error)
        where TError : Error
    {
        return new ObjectResult(new ProblemDetails
        {
            Title = error.Code,
            Type = GetType(error),
            Status = GetStatus(error),
            Detail = error.Message
        });
    }

    private static string GetType<TError>(TError error)
        where TError : Error
    {
        return error switch
        {
            DuplicateEntryError => "https://datatracker.ietf.org/doc/html/rfc9110#name-409-conflict",
            InvalidCredentialsError => "https://datatracker.ietf.org/doc/html/rfc9110#name-400-bad-request",
            NotFoundError => "https://datatracker.ietf.org/doc/html/rfc9110#name-404-not-found",
            UnauthorizedError => "https://datatracker.ietf.org/doc/html/rfc9110#name-401-unauthorized",
            ValidationError => "https://datatracker.ietf.org/doc/html/rfc9110#name-400-bad-request",
            _ => throw new ArgumentOutOfRangeException(nameof(error),
                $"'{error.GetType()}' is an unknown error type.")
        };
    }

    private static int GetStatus<TError>(TError error)
        where TError : Error
    {
        return error switch
        {
            DuplicateEntryError => StatusCodes.Status409Conflict,
            InvalidCredentialsError => StatusCodes.Status400BadRequest,
            NotFoundError => StatusCodes.Status404NotFound,
            UnauthorizedError => StatusCodes.Status401Unauthorized,
            ValidationError => StatusCodes.Status400BadRequest,
            _ => throw new ArgumentOutOfRangeException(nameof(error),
                $"'{error.GetType()}' is an unknown error type.")
        };
    }
}