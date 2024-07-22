using ReqSense.Application.Common.Errors.Base;

namespace ReqSense.Application.Common.Errors;

public static class UserErrors
{
    public static NotFoundError NotFound(string id) =>
        new("User.NotFound", $"User with id {id} was not found.");

    public static UnauthorizedError Unauthorized() =>
        new("User.Unauthorized", "You must sign in to perform this action.");

    public static InvalidCredentialsError InvalidCredentials() =>
        new("User.InvalidCredentials", "Either the email or password is incorrect.");

    public static ValidationError Validation(IEnumerable<Error> errors) =>
        new("User.Validation", string.Join("; ", errors.Select(e => e.Message)));
}