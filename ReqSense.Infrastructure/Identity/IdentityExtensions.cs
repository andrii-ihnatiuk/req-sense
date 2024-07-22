using Microsoft.AspNetCore.Identity;
using ReqSense.Domain.Common;

namespace ReqSense.Infrastructure.Identity;

public static class IdentityExtensions
{
    public static Error ToResultError(this IdentityError error) => new Error(error.Code, error.Description);
}