using Microsoft.AspNetCore.Identity;
using ReqSense.Application.Common.Exceptions;

namespace ReqSense.Infrastructure.Identity;

public static class IdentityExtensions
{
    public static async Task ThrowIfFailedAsync(this Task<IdentityResult> resultTask, string? message = null)
    {
        var result = await resultTask;
        if (!result.Succeeded)
        {
            throw new IdentityException(message ?? string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
}